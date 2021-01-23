    using UnityEngine;
    using System.Collections;
    
    public class Spawn : MonoBehaviour 
    {
    	public Vector3 Position;
    	[SerializeField]
    	GameObject ThingToSpawn;
    	void Start () 
    	{
    		if (ThingToSpawn == null) 
    		{
    			Debug.LogError ("ThingToSpawn is null for instance of Spawn.cs at "+transform.name);
    			return;
    		}
    		Instantiate (ThingToSpawn,Position,Quaternion.identity);
    	}
    }
