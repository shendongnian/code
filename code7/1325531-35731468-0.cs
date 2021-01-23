    using UnityEngine;
    using System.Collections;
    
    public class NewBehaviourScript : MonoBehaviour {
    
    	// Use this for initialization
    	void Start () {
    		StartCoroutine(ResourceTickOver(3.0f));
    	}
    	
    	// Update is called once per frame
    	void Update () {
    		
    	}
    
    	IEnumerator ResourceTickOver(float waitTime)
    	{
    		while (true) // Do this as long this script is running.
    		{
    			print (Time.time);
    			yield return new WaitForSeconds(waitTime);
    			print (Time.time);
    
    			// Update Resources inside this loop or call something that will.
    
    		}
        }
    }
 
