    public class Movement : MonoBehaviour
    {
        public int movespeed = 20;
        public Vector3 userDirection = Vector3.right;
    
        void Start()
        {
            //Send Movement instance to the score script
            GameObject scoreGameObject = GameObject.Find("GameObjectScoreIsAttachedTo");
            scoreGameObject.GetComponent<score>().rereiveMovementInstance(this);
        }
    
        public void Update()
        {
            transform.Translate(userDirection * movespeed * Time.deltaTime);
        }
    }
