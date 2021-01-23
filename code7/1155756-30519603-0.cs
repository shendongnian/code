    public class SpinGameObject : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKey (KeyCode.LeftArrow))
            {
                transform.Rotate(0, 0, rotationAngle * Time.deltaTime, Space.World);
            }
            
            if (Input.GetKey (KeyCode.RightArrow))
            {
                transform.Rotate(0, 0, - rotationAngle * Time.deltaTime, Space.World);
            }
        }
    }
