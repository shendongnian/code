    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    public class DestroyPlayerOnTouch : MonoBehaviour {
    	public GameObject panel;
           bool hasshield = false;
    	
    	void OnCollisionEnter(Collision col)
    	{
    	      if (col.gameObject.tag == "Monster"  && !hasshield) 
    		{ 
    			panel.SetActive (true);
    		}
    
    		else if(col.gameObject.tag == "Monster" && hasshield)
    		{
    			panel.SetActive (false);
    		}
    	}
    
    	void OnTriggerEnter(Collider other) 
    	{
    		if (other.gameObject.tag == "Shield") 
    		{
    			Debug.Log("hasshield!");
    			hasshield = true;
    		}
    	}
    }
    	
