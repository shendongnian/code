    using UnityEngine;
    public class MovementController : MonoBehaviour {
	
	public Rigidbody rigidbody;
	float angle = 0f;
	const float SPEED = 1f;
	float multiplier = 1f;
	void FixedUpdate(){
		if ( Input.GetKey (KeyCode.LeftArrow) )
			angle -= Time.deltaTime * SPEED * multiplier;
		else if( Input.GetKey (KeyCode.RightArrow) )
			angle += Time.deltaTime * SPEED * multiplier;
		rigidbody.velocity = new Vector2(Mathf.Sin(angle) * SPEED, Mathf.Cos(angle) * SPEED);
	    }
    }
