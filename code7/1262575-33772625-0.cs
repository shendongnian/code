        using UnityEngine;
        using System.Collections;
    
        public class BoxDestroy : MonoBehaviour 
        {   
            void OnTriggerEnter(Collider collider)
            {
                if (collider.gameObject.tag == "Player") 
                {
                    GameObject[] remainingObj = GameObject.FindGameObjectsWithTag("Enemy");
                    if (remainingObj.Length == 1)
                    {
                        Application.LoadLevel("name of level you want to load");
                    }
                    Destroy(gameObject);
                }
            } 
        }
