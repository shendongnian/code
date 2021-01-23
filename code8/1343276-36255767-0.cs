    using UnityEngine;
    using System.Collections;
    public class CharacterMovement : MonoBehaviour{
	public float speed;
	private Rigidbody2D rbtd;
	void Start () 
	{
		rbtd = GetComponent<Rigidbody2D> ();
	}
	void FixedUpdate()
	{
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition,
												Vector3.forward);
	
		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		rbtd.angularVelocity = 0;
		float input = Input.GetAxis ("Vertical");
		rbtd.AddForce (gameObject.transform.up * speed * input);
	}
    }
