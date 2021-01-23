    using UnityEngine;
    using System.Collections;
    
    public class WallTransport : MonoBehaviour {
    
        public Collider2D destination;
        public LayerMask layer;
    
        void OnTriggerEnter2D(Collider2D other) {
            if(((1 << other.gameObject.layer) & layer) != 0) {
                Vector2 destPos = destination.transform.position;
                other.transform.position = new Vector2(destPos.x + 1, other.transform.position.y);
                //                                     ^^^^^^^^^^^^^
            }
        }
    }
