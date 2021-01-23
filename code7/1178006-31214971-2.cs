    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    public class MainClass : MonoBehaviour {
    	
    	private List<DNA> generation = new List<DNA>();
    	// Use this for initialization
    	void Start () {
    		generation.Add(new DNA());
    		generation[0].init();
    		for(int i = 0; i < generation[0].boolLength; i++)
    		{
    			Debug.Log(generation[0].chromosone[i]);
    		}
    	}
    	
    	// Update is called once per frame
    	void Update () {
    	
    	}
    }
