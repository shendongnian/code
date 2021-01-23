    using UnityEngine;
    using System.Collections.Generic;
    using System.Linq;
    
    public class SceneUpdateManager : MonoBehaviour {
    
    	private static List<ManagedUpdateBehavior> list;
    
    	private void Start () 
    	{
    		list = Object.FindObjectsOfType<ManagedUpdateBehavior> ().ToList ();
    	}
    
    	public static void AddBehavior(ManagedUpdateBehavior behaviour)
    	{
    		list.Add (behaviour);
    	}
    
    	private void Update () {
    		var count = list.Count;
    
    		for (var i = 0; i < count; i++)
    		{
    			list [i].UpdateMe();
    		}
    	}
    }
