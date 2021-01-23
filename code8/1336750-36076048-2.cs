    using UnityEngine;
    using System.Collections;
    
    public class turnofflight : MonoBehaviour {
    
    	public GameObject[] roomlights;
    
    	// Use this for initialization
    	void Start () {
    		roomlights = GameObject.FindGameObjectsWithTag("light_comp");
    		foreach (GameObject light in roomlights)
    			Debug.Log(light.name);
    	}
    
    	// Update is called once per frame
    	void Update () {
    
    		foreach (GameObject single_light in roomlights)
    			{
    			if ((single_light.GetComponent<Light>().intensity == 1.0f))
    					single_light.SetActive(false);
    				else
    					single_light.SetActive(true);
    			}
    
    	}
    }
