    using UnityEngine;
    using System.Collections;
       public class SpawnExtra : MonoBehaviour {
	   public GameObject deathAnimation;
 
	   public static SpawnExtra instance;
	   void Start () 
	   {
		    instance = this;
	   }
	   public void SpawnDeathAnimation(Vector3 position)
	   {
	    	Instantiate (deathAnimation, position, Quaternion.identity);
	   }
    }
