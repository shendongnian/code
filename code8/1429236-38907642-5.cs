    public class Movement : MonoBehaviour
    {
        public int movespeed = 20;
        public Vector3 userDirection = Vector3.right;
    
        score mySpeed;
    
        void Start()
        {
            //Send Movement instance to the score script
            GameObject scoreGameObject = GameObject.Find("GameObjectScoreIsAttachedTo");
            mySpeed = scoreGameObject.GetComponent<score>();
        }
    
        public void Update()
        {
            transform.Translate(userDirection * mySpeed.getMoveSpeed() * Time.deltaTime);
        }
    }
