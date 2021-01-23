        using UnityEngine;
    using System.Collections;
    
    public class BalloonTethering : MonoBehaviour {
    
        public SpringJoint2D theSpringJoint;
        public Rigidbody2D theTether;
    
        // Use this for initialization
        void Start () {
              theSpringJoint =  this.gameObject.GetComponent<SpringJoint2D>();
        }
    
        // Update is called once per frame
        void Update () {
            
        }
    }
