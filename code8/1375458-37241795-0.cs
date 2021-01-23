    using UnityEngine;
    using System.Collections;
    
    public class jumpAntigravity : MonoBehaviour {
    
        Vector2 upForce;
    	
    	void Start () {
            //Up force set to double of gravity
            upForce = new Vector2(0, 9.8f*2);
    	}
    	
    	void Update () {
            if (Input.GetKey(KeyCode.Space))
            {
                print("Spacebar is down");
                GetComponent<Rigidbody2D>().AddForce(upForce);
            }
    	}
    }
