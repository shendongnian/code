    using UnityEngine;
    using System.Collections;
    public class Coin : MonoBehaviour {
        // Drag your Game Manager object into this slot in the inspector
        public GameObject GameManager;
        public static int coinWorth = 1;
        void OnCollisionEnter(Collision other)
        {
            // If the coin is collided into by an object tagged 'player'
            if (other.transform.tag == "Player")
           {
                // retrieve the gamemanager component from the game manager object and increment its value
                GameManager.GetComponent<GameManager4>().coinValue++;
                // Destroy this instance of the coin
                Destroy(gameObject);
           }
        }
    }
