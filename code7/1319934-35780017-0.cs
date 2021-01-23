    public class FixedRotate : MonoBehaviour
    {
        [SerializeField]
        private float   m_rotationAngle;
        [SerializeField]
        private float   m_rotationSpeed;
        private Vector3 m_targetRotation;
    
        public void Start()
        {
            m_targetRotation = transform.eulerAngles;
        }
    
        public void Update()
        {
            //Left
            if(Input.GetKeyDown(KeyCode.A))
                m_targetRotation.y -= m_rotationAngle;
            //Right
            if (Input.GetKeyDown(KeyCode.D))
                m_targetRotation.y += m_rotationAngle;
    
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(m_targetRotation), m_rotationSpeed);
        }
    }
