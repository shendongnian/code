    using UnityEngine;
    using System.Collections;
    
    public class GameObjectKiller : MonoBehaviour 
    {
    	public GameObject otherGameObject;
    	
    	private void Update()
    	{
    		if(Input.GetKeyDown(KeyCode.A))
    		{
    			Destroy(otherGameObject);
    		}
    	}
    }
