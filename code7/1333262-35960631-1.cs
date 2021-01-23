    public class PlayerController : MonoBehaviour {
    Rigidbody _rb; //DECLARE _rb
        void FixedUpdate(){
            float moveHorizontal = Input.GetAxis ("Horizontal");
            float moveVertical = Input.GetAxis ("Vertical");
    
            _rb = GetComponent<Rigidbody> ();
    
            _rb.position = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        }
    
        }
