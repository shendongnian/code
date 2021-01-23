    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    
    public class Spawn : MonoBehaviour 
    {
    	public ReadOnlyCollection<Vector3> Positions;
    	public List<Transform> Transforms=new List<Transform>();
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
    		var positionsList =
    			Enumerable.Range (0, 3)
    				.Select (i => Transforms [Random.Range (0, Transforms.Count)].position)
    				.ToList ();
    		Positions = new ReadOnlyCollection<Vector3> (positionsList);
    			
    		Instantiate (ThingToSpawn,Positions[0],Quaternion.identity);
    	}
    }
