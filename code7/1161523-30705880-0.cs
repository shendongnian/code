        public class MyBall : MonoBehaviour{
           private Transform _myTransform = null;
           private Vector3 _lastPosition = null;
    
           private void Awake(){
              _myTransform = transform;
              _lastPosition  = _myTransform.position;
           }
    
           private void Update(){
              if(_lastPosition == _myTransform.position){
                 Debug.Log("Did not move");
              }else{
                 Debug.Log("Moved");
              }
              _lastPosition = _myTransform.position;
           }
        }
