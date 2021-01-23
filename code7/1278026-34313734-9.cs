    using UnityEngine;
    using System.Collections;
    
    public class borderListener : MonoBehaviour {
    		public Respawn rS;
    	
    		void OnTriggerEnter2D(Collider2D target){
    				rS.spawnIt ();
    		
    		}
    	
    }
