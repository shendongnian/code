    using UnityEngine;
    using System.Collections;
    
    public class GameManager : MonoBehaviour {
    
        public int currentLevel = 0;
    
        void OnCollisionEnter(Collision other)
        {
            if (other.transform.tag == "Complete") {
                currentLevel++; //first change level number
                Application.LoadLevel (currentLevel); //then load
            }
        }
    }
