    public class Door : MonoBehaviour
    {
        public float ySensitivity = 300f;
        public float frontOpenPosLimit = 45;
        public float backOpenPosLimit = 45;
    
        public GameObject frontDoorCollider;
        public GameObject backDoorCollider;
    
        bool moveDoor = false;
        DoorCollision doorCollision = DoorCollision.NONE;
    
    
        // Use this for initialization
        void Start()
        {
            StartCoroutine(doorMover());
        }
    
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse down");
    
                RaycastHit hitInfo = new RaycastHit();
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
                {
                    if (hitInfo.collider.gameObject == frontDoorCollider)
                    {
                        moveDoor = true;
                        Debug.Log("Front door hit");
                        doorCollision = DoorCollision.FRONT;
                    }
                    else if (hitInfo.collider.gameObject == backDoorCollider)
                    {
                        moveDoor = true;
                        Debug.Log("Back door hit");
                        doorCollision = DoorCollision.BACK;
                    }
                    else
                    {
                        doorCollision = DoorCollision.NONE;
                    }
                }
            }
    
            if (Input.GetMouseButtonUp(0))
            {
                moveDoor = false;
                Debug.Log("Mouse up");
            }
        }
    
        IEnumerator doorMover()
        {
            bool stoppedBefore = false;
            float yRot = 0;
    
            while (true)
            {
                if (moveDoor)
                {
                    stoppedBefore = false;
                    Debug.Log("Moving Door");
    
                    yRot += Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;
    
    
                    //Check if this is front door or back
                    if (doorCollision == DoorCollision.FRONT)
                    {
                        Debug.Log("Pull Down(PULL TOWARDS)");
                        yRot = Mathf.Clamp(yRot, -frontOpenPosLimit, 0);
                        Debug.Log(yRot);
                        transform.localEulerAngles = new Vector3(0, -yRot, 0);
                    }
                    else if (doorCollision == DoorCollision.BACK)
                    {
                        Debug.Log("Pull Up(PUSH AWAY)");
                        yRot = Mathf.Clamp(yRot, 0, backOpenPosLimit);
                        Debug.Log(yRot);
                        transform.localEulerAngles = new Vector3(0, yRot, 0);
                    }
                }
                else
                {
                    if (!stoppedBefore)
                    {
                        stoppedBefore = true;
                        Debug.Log("Stopped Moving Door");
                    }
                }
    
                yield return null;
            }
    
        }
    
    
        enum DoorCollision
        {
            NONE, FRONT, BACK
        }
    }
 
