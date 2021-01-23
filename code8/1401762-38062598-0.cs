       Public class ObjectListener
        {
           public string ObjectName {get; set;}
           public Vector2 ObjectVector {get; set;}
        }
        
     
    
           public class CreateObject : MonoBehaviour 
            {
            List<ObjectListener> _gameObjectListener = new List<ObjectListener>();
            
            void Update()
            {
             private GameObject _gameObject  ; // you must create _gameObject 
                                               // and set tranform.Postion  maybe you 
                                               //   can use a method returned gameObject 
            
            Instantiate(_gameObject, _gameObject.transform.position, Quaternion.identity);
            
            _gameObjectListener.Add(new ObjectListener
                                        {
                                          ObjectName =  _gameObject.Name,
                                          ObjectVector  =  _gameObject.transform.postion
                                        });
        
                 
            
            }
            
         }
