    public class Test : MonoBehaviour {
    	public float explosionStrength  = 100;
    
    	void OnCollisionEnter2D( Collision2D _other) 
    	{
    		if (_other.collider.gameObject.name == "Bouncy object")
    			_other.rigidbody.AddExplosionForce(explosionStrength, this.transform.position,5);
    	}
    }
