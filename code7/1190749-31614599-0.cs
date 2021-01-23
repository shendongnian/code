    using UnityEngine;
    using System.Collections;
     public class PlayerControl : MonoBehaviour
    {  public Rigidbody rb;
	public float xMax,xMin,zMax,zMin;
	public float velocity;
	void Start() {
		rb = GetComponent<Rigidbody>();
	}
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement*velocity;
		Vector3 current_position = rb.position;
		rb.position = new Vector3 ( Mathf.Clamp(current_position.x,xMin,xMax),
		                                   0.0f,
		                           Mathf.Clamp(current_position.z, zMin, zMax)
		                                   );
                          }
                       }
