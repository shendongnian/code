    public class Tree : MonoBehaviour
    {
    
        public int Health = 5;
        public Transform logs;
        public Transform coconut;
        public GameObject tree;
    
        public Camera myCamera;
    
        public int speed = 8;
    
        void Start()
        {
            tree = this.gameObject;
            GetComponent<Rigidbody>().isKinematic = true;
            myCamera = GameObject.FindObjectOfType<Camera>();
        }
    
        // Update is called once per frame
        void Update()
        {
            if (Health > 0)
            {
                if (Vector3.Distance(transform.position, myCamera.transform.root.transform.position) < 10f)
                {
                    if (Input.GetKeyDown(KeyCode.R) && WeaponSwitching.check == true)
                    {
                        Ray ray = new Ray(myCamera.transform.position, myCamera.transform.forward);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit, 10f))
                        {
                            if (hit.collider.gameObject == gameObject)
                            {
                                --Health;
                            }
                        }
                    }
                }
            }
    
            if (Health <= 0)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().AddForce(transform.forward * speed);
                DestroyTree();
            }
        }
    
        void DestroyTree()
        {
    
            wait();
    
            Destroy(tree);
    
            Vector3 position = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
            Instantiate(logs, tree.transform.position + new Vector3(0, 0, 0) + position, Quaternion.identity);
            Instantiate(logs, tree.transform.position + new Vector3(2, 2, 0) + position, Quaternion.identity);
            Instantiate(logs, tree.transform.position + new Vector3(5, 5, 0) + position, Quaternion.identity);
    
            Instantiate(coconut, tree.transform.position + new Vector3(0, 0, 0) + position, Quaternion.identity);
            Instantiate(coconut, tree.transform.position + new Vector3(2, 2, 0) + position, Quaternion.identity);
            Instantiate(coconut, tree.transform.position + new Vector3(5, 5, 0) + position, Quaternion.identity);
        }
    
        IEnumerator wait()
        {
            yield return new WaitForSeconds(7.0f);
        }
    }
