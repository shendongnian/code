    Using UnityEngine;
    using System.Collections;
    public class Example : MonoBehaviour{
     void OnCollisionExit (Collision collisioninfo){
        GetComponent<Animation> ().Stop ("Jumping");
         }
    }
