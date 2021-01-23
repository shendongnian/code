    public class CollideCtrl : MonoBehaviour 
    {
    	public float speed = 500f;
    	void OnCollisionEnter2D (Collision2D col) {
    		if(col.gameObject.CompareTag("Player")){
    			Debug.Log("Col");
    			Rigidbody2D rig = col.gameObject.GetComponent<Rigidbody2D>();
    			if(rig == null) { return;}
    			Vector2 velocity = rig.velocity;
    			rig.AddForce( -velocity * speed); 
    		}
    	}
    }
