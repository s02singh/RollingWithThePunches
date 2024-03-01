using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{   
    public GameObject bow;
    public GameObject player;
    public float horizontalForce = 15f;
    public float verticalForce = 1f;

    public void Launch(GameObject projectile)
    {
        // Get the position of the bow
        Vector3 startingPosition = bow.transform.position;

        // Get the direction from the starting position to the player
        Vector3 direction = (player.transform.position - startingPosition).normalized;

        // Set rotation of projectile
        Quaternion rotation = Quaternion.LookRotation(direction) * Quaternion.Euler(90, 0, 0);

        // Instantiate the projectile at the starting position with proper rotation
        Rigidbody rb = Instantiate(projectile, startingPosition, rotation).GetComponent<Rigidbody>();

        // Add forces to the projectile
        rb.AddForce(direction * horizontalForce, ForceMode.Impulse);
        rb.AddForce(transform.up * verticalForce, ForceMode.Impulse);

        // Destroy the projectile after a delay
        Destroy(rb.gameObject, 2f);
    }
}
