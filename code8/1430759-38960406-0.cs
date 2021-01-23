    //PUBLIC
    public float distance;      
    public float fspeed;
    public float uspeed;
    //PRIVATE
    private Rigidbody rigidBody;
   
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.freezeRotation = true;
    }
    
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, distance + 0.1F))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rigidBody.AddForce(new Vector3(0, uspeed, fspeed));
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                rigidBody.AddForce(new Vector3(0, uspeed, -fspeed));
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                rigidBody.AddForce(new Vector3(fspeed, uspeed, 0));
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rigidBody.AddForce(new Vector3(-fspeed, uspeed, 0));
            }
        }
    }
----------
    public float distance
