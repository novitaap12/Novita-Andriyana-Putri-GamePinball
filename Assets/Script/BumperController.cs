using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;

    private Renderer renderer;
    private Animator animator;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

        renderer.material.color = color;
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();

            // Check if Rigidbody component exists before accessing its properties
            if (bolaRig != null)
            {
                bolaRig.velocity *= multiplier;
            }
            else
            {
                Debug.LogError("Rigidbody component not found on the 'bola' GameObject.");
            }

            // Trigger the "hit" animation using the Animator component
            if (animator != null)
            {
                animator.SetTrigger("hit");
            }
            else
            {
                Debug.LogError("Animator component not found on the current GameObject.");
            }
        }
    }
}
