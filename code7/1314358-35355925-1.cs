    using UnityEngine;
    using System.Collections;
    
    public class PlayerProjectileDoom : MonoBehaviour {
    
        void Start(){
            Destroy(gameObject, 2F);
        }
        // For 3D colliders
        void OnTriggerEnter(Collider coll) {
                Destroy(gameObject);
        }
        // For 2D colliders
        void OnTriggerEnter2D(Collider2D coll) {
                Destroy(gameObject);
        }
        
        void Update () {
            
        }
    
    }
