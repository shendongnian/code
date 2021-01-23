    public class Ball : MonoBehaviour {
    
        Rigidbody2D body;
        float mousePosInBlocks;
    	bool wasDropped = false;
    	
        void Start () {
            body = GetComponent<Rigidbody2D> ();
            body.isKinematic = true;
        }
    
        void Update () {
    		//Don't do anything after the ball is dropped.
    		if(wasDropped)
    			return;
    	
            if (Input.GetMouseButtonDown (0)) {
                body.isKinematic = false;
    			wasDropped = true;
            }
    
            Vector3 ballPos = new Vector3 (0f, this.transform.position.y, 0f);
            mousePosInBlocks = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            //not go outside from border
            ballPos.x = Mathf.Clamp (mousePosInBlocks, -2.40f, 2.40f);
    
            body.position = ballPos;
        }
    }
