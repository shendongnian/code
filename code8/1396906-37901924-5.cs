    public class PlayerMove : MonoBehaviour
    {
    
        Vector3 pos;
        public float speed;
        public static bool inside;
        public Dictionary<string, GameObject> obstacleDictionary;
    
        GameObject gob;
    
        void Awake()
        {
            obstacleDictionary = new Dictionary<string, GameObject>();
        }
    
        void Start()
        {
            pos = transform.position;
        }
    
        void Update()
        {
            gob = GetObjectAt(transform.position);
            if (gob == null) inside = false;
            else inside = true;
            print(inside);
    
    
            #region Control
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                GameObject go = GetObjectAt(transform.position - new Vector3(speed, 0, 0));
                if (go == null || go.GetComponent<ObstacleMove>().openSide == "right")
                {
                    if (inside && gob.GetComponent<ObstacleMove>().openSide == "left") inside = false;
                    /*if(inside && gob.CompareTag("BigRed") && go.CompareTag("BigRed")) { }
                    else */
                    pos.x -= speed;
                }
            }
    
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                GameObject go = GetObjectAt(transform.position + new Vector3(speed, 0, 0));
                if (go == null || go.GetComponent<ObstacleMove>().openSide == "left")
                {
                    if (inside && gob.GetComponent<ObstacleMove>().openSide == "right") inside = false;
                    pos.x += speed;
                }
            }
    
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                GameObject go = GetObjectAt(transform.position - new Vector3(0, speed, 0));
                if (go == null || go.GetComponent<ObstacleMove>().openSide == "up")
                {
                    if (inside && gob.GetComponent<ObstacleMove>().openSide == "down") inside = false;
                    pos.y -= speed;
                }
            }
    
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                GameObject go = GetObjectAt(transform.position + new Vector3(0, speed, 0));
                if (go == null || go.GetComponent<ObstacleMove>().openSide == "down")
                {
                    if (inside && gob.GetComponent<ObstacleMove>().openSide == "up") inside = false;
                    pos.y += speed;
                }
            }
            #endregion
    
            transform.position = pos;
    
            if (inside && gob.transform.position != transform.position)
            {
                print("change");
                ChangeObstacleDictionary(gob.transform.position, transform.position);
                gob.transform.position = transform.position;
    
            }
        }
    
        public GameObject GetObjectAt(Vector3 position)
        {
            string pos = position.x + "_" + position.y;
            if (obstacleDictionary.ContainsKey(pos) == true)
            {
                print(obstacleDictionary[pos]);
                return obstacleDictionary[pos];
            }
    
            else return null;
        }
    
        public void ChangeObstacleDictionary(Vector3 lastPosition, Vector3 newPos)
        {
    
            string lastPosString = lastPosition.x + "_" + lastPosition.y;
            string newPosString = newPos.x + "_" + newPos.y;
    
            //print("test" + lastPosString + " " + newPosString);
            if (lastPosString != newPosString)
            {
                obstacleDictionary.Remove(lastPosString);
                obstacleDictionary.Add(newPosString, gob);
            }
        }
    
    }
