    using UnityEngine;
    using System.Collections;
    
    public class CoinPickup : MonoBehaviour 
    {
        public AudioSource coinSound; //set in inspector    
    
        void OnTriggerEnter(Collider other)  // other is a reference to the other trigger collider we have touched
        {
            if (other.gameObject.tag == "Player") //or you could do other.gameObject.name == "Player"
            {
    	        coinSound.Play(); //play the coin sound
    	        Destroy(gameobject); // destroy our coin, it has been picked up!
            }
        }
    }
