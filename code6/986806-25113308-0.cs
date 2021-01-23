    using UnityEngine;
    using System.Collections;
    
    public class Wander : MonoBehaviour {
	    
		protected Vector3 velocity;
        protected Vector2 waypoint;
        protected float speed;
        
        // Use this for initialization
        void Start () {
            speed = gameObject.GetComponent<Move>().playerSpeed;
            RandomizeWaypoint();
        }
    
        void RandomizeWaypoint(){
            waypoint = Random.insideUnitCircle * 10;
        }
    
        // Update is called once per frame
        void Update () {
            transform.position = Vector3.SmoothDamp( transform.position, waypoint, ref velocity, Time.deltaTime * speed );
			transform.rotation = Quaternion.AngleAxis( Mathf.Atan2( velocity.y, velocity.x ) * Mathf.Rad2Deg, Vector3.forward );
            if( Vector3.Distance( transform.position, waypoint ) < 3 ){
                RandomizeWaypoint();
            }
        }
    }
