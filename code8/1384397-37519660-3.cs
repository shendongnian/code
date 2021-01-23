    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Spawn : MonoBehaviour 
    {
    	public List<Transform> Transforms=new List<Transform>();
    	public Vector3 LeftPosition{ get; private set;}
    	public Vector3 MiddlePosition{ get; private set;}
    	public Vector3 RightPosition{ get; private set;}
    	[SerializeField]
    	GameObject ThingToSpawn;
    	void Start () 
    	{
    		if (ThingToSpawn == null) 
    		{
    			Debug.LogError ("ThingToSpawn is null for instance of Spawn.cs at "+transform.name);
    			return;
    		}
    		if (Transforms == null) 
    		{
    			Debug.LogError ("Transforms variable is null for instance of Spawn.cs at "+transform.name);
    			return;
    		}
    		if (Transforms.Count == 0) 
    		{
    			Debug.LogError ("No transforms provided for instance of Spawn.cs at "+transform.name);
    			return;
    		}
    		var Positions = 
    			Enumerable.Range (0, 3)
    				.Select (i => Transforms [Random.Range(0,Transforms.Count)].position)
    				.OrderBy (i => i.x)
    				.ToList ();
    		LeftPosition = Positions [0];
    		MiddlePosition = Positions [1];
    		RightPosition = Positions [2];
    		Instantiate (ThingToSpawn,new[]{LeftPosition,MiddlePosition,RightPosition}[Random.Range(0,3)],Quaternion.identity);
    	}
    }
