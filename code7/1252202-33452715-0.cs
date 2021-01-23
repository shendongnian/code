    using UnityEngine;
    using System.Collections;
    public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
    private Vector3 input;
        void Update () 
        {
            input = new Vector3(Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
            GetComponent<Rigidbody>().AddForce(input * moveSpeed);
        }
    }
