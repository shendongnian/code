    using UnityEngine;
    using System.Collections;
    
    public class Test : MonoBehaviour 
    {
    
    	void Start()
    	{
    		MonoBehaviour[] scripts = this.GetComponents<MonoBehaviour> ();
    
    		foreach (MonoBehaviour mb in scripts)
    		{
    			Debug.Log (mb.GetType ().Name);
    		}
    	}
    }
