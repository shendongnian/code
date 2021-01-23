    using UnityEngine;
    using System.Collections;
    using System.Collections;
    
    public class TestDelagets : MonoBehaviour {
    
    	void Start () {
    		SolarSystem s = new SolarSystem();
    		Planet p = new Planet();
    		string g = "";
    		int[] i = DelagetsAndEvents.UnitSpawn(g);
    
    		foreach(int f in i)
    		{
    			Debug.Log(f);
    		}
    	}
    }
