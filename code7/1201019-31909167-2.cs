    public class CollisionObject : MonoBehaviour 
    {
    	[SerializeField]
    	private bool canCollide = true;
    
    	void OnCollisionEnter(Collision collision)
    	{
    		if (canCollide == true) {
    			canCollide = false;
    			ContactPoint contactPoint = collision.contacts [0];
    			
    			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    			cube.transform.localScale = new Vector3(5, 5, 5);
    			cube.transform.position = contactPoint.point;
    			
    			iTween.MoveTo(cube, iTween.Hash(
    				"y", 40, 
    				"time", 0.5));
    			iTween.MoveTo(cube, iTween.Hash(
    				"position", new Vector3 (55, 79, 10), 
    				"time", 0.5f,
    				"delay", 0.5f,
    				"oncompletetarget", this.gameObject, 
    				"oncompleteparams", cube,
    				"oncomplete", "DestroyCubeAndIncrementGauge"
    			));
    		}
    	}
    
    	public void DestroyCubeAndIncrementGauge(GameObject cube)
    	{
    		// destroy the cube
    		Destroy(cube);
    		// inform the PlayerCar to IncrementGauge
    		GameObject.Find("PlayerCar").SendMessage("IncrementGauge");
    	}
    }
