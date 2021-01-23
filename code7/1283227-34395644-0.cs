    public class Move : MonoBehaviour {
    	public Rigidbody2D rig;
    	public float speed = 0.2f;
    	public float maxSpeed = 5f;
    	void FixedUpdate () 
    	{
    		Vector2 vel = new Vector2 ( Input.GetAxis("Horizontal") /5f, Input.GetAxis("Vertical")/5f);
    		vel.Normalize ();
    		if (vel.sqrMagnitude > 0f && rig.velocity.sqrMagnitude < maxSpeed) {
    			rig.AddForce (vel * speed, ForceMode2D.Impulse);
    		} else {
    			rig.velocity = Vector2.zero;
    		}
    	}
    }
