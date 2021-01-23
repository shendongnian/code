    using UnityEngine;
    using System.Collections;
    
    public class Object2 : MonoBehaviour {
    
    	[SerializeField]
    	private GameObject BallClone;
    
    	public GameObject mine;
    
    
    	void OnCollisionEnter2D(Collision2D target){
    
    		Destroy (target.gameObject);
    
    		mine = Instantiate (BallClone,new Vector3(0f,2f,59f),Quaternion.identity) as GameObject;
    
    
    	}
    
    
    	
    public void ButtonClick(){
    //this is just an example. You might wanna to cache this info for better practice and not call GetComponent all the time
        		mine.GetComponent<Rigidbody2D> ().isKinematic = false;
        	}
    
    
    
    	
    }
