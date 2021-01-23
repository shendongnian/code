    public GameObject shell;
    public Transform barrelEnd;
    public float launchForce = 200;
    
    Transform cameraTransform;
    
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }
    
    void Update()
    {
    
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }
    void Fire()
    {
        GameObject tempObj;
        tempObj = Instantiate(shell, barrelEnd.position, barrelEnd.rotation) as GameObject;
        Rigidbody projectile = tempObj.GetComponent<Rigidbody>();
    
        projectile.velocity = cameraTransform.forward * launchForce;
    }
