    using UnityEngine;
    using System.Collections;
    public class GameManager4 : MonoBehaviour {
        // Declare the coinValue as a public int so that it can be accessed from the coin script directly
        public int coinValue = 0;
        void Update ()
        {
            // This shouldn't be necessary to check on each update cycle
            //coinValue = Coin.coinWorth;
        }
        void OnCollisionEnter(Collision other){
            if (other.transform.tag == "Complete" && coinValue > 0) {
                Application.LoadLevel(1);
            }
        }
    }
