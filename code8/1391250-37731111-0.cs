    using UnityEngine;
    using System.Collections;
    
    public class suivre : MonoBehaviour 
    {    
        public float speed = 3f;
        GameObject perso;
               
        void Start () 
        {
            perso = GameObject.FindGameObjectWithTag ("Player");
            InvokeRepeating ("follower", 1, 1);
        }
    
        void follower() 
        {    
            Vector3 directionToPlayer = perso.transform.position - this.transform.position;
    		directionToPlayer.Normalize ();	
    
            GetComponent<Rigidbody>().AddForce(directionToPlayer * speed);
        }
    }
