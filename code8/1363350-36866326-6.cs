    public class ForwardBack : MonoBehaviour 
    {
        public float roatationSpeed;
        private Transform thisTransform = null;
        void Start () 
        {
            thisTransform = GetComponent<Transform>();
        }
        void Update () 
        {
            if(Input.GetKey(KeyCode.RightArrow)
            {
                 thisTransform.Rotate(Vector3.Right * rotationSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.LeftArrow)
            {
                 thisTransform.Rotate(Vector3.Left * rotationSpeed * Time.deltaTime);
            }
        }
    }
