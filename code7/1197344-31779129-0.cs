    public class ExampleClass : MonoBehaviour {
        void OnCollisionStay2D(Collision2D coll) {
            if (coll.gameObject.tag == "Button1")
                b1 = true;
            
        }
    }
