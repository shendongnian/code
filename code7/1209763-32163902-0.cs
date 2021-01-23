    public class ExampleBehaviour : MonoBehaviour {
    
        void Awake () {
            Debug.Log(gameObject.name);        //Prints "GameObjectB" to the console
            Debug.Log(transform.parent.name);  //Prints "GameObjectA" to the console
        }
    
    }
