        using UnityEngine;
    using System.Collections;
    
    public class NewBehaviourScript : MonoBehaviour {
    
    	// Use this for initialization
    	void Start () {
    		if (Input.GetKey("escape"))
    			Application.Quit();
    	}
    	
    	// Update is called once per frame
    	void Update () {
    		if (Input.GetKey("escape"))
    			Application.Quit();
    	}
    }
