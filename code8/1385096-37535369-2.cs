    public GameObject bulletPrefab;
    public float shootSpeed = 300;
    
    Transform cameraTransform;
    
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }
    
    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootBullet();
        }
    }
    void shootBullet()
    {
        GameObject tempObj;
        //Instantiate/Create Bullet
    
        tempObj = Instantiate(bulletPrefab) as GameObject;
    
        //Set position  of the bullet in front of the player
        tempObj.transform.position = transform.position + cameraTransform.forward;
    
        //Get the Rigidbody that is attached to that instantiated bullet
        Rigidbody projectile = GetComponent<Rigidbody>();
    
        //Shoot the Bullet 
        projectile.velocity = cameraTransform.forward * shootSpeed;
    }
