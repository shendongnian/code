    using UnityEngine;
    
    public class RotateChild : MonoBehaviour
    {
       void Update()
       {
          if( Input.GetKey( KeyCode.W ) )
             transform.Rotate( 1, 0, 0 );
          if( Input.GetKey( KeyCode.S ) )
             transform.Rotate( -1, 0, 0 );
          if( Input.GetKey( KeyCode.A ) )
             transform.Rotate( 0, -1, 0 );
          if( Input.GetKey( KeyCode.D ) )
             transform.Rotate( 0, 1, 0 );
       }
    }
