    public float jumpSpeed = 2;
    public float maxSpeed = 1; 
    Rigidbody rb;
    
    void Start()
    {
    	rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {	
    	var newVelocity = rb.velocity;
    	if (Input.GetMouseButtonDown (0))
    		newVelocity.y = jumpSpeed;
    
    	newVelocity.x = maxSpeed;
    
    	rb.velocity = newVelocity;
    }
