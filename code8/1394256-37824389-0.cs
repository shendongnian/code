    public class Paddle : MonoBehaviour
    {
        public float mouseSpeed = 100;
        public float keySpeed = 0.1f;
    
    
        void Update()
        {
            float x = 0;
            x = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSpeed;
    
            if (x == 0)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    x = Vector3.left.x * keySpeed;
                }
    
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    x = Vector3.right.x * keySpeed;
                }
    
            }
            transform.Translate(x, 0, 0);
        }
    }
