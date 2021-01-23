    Rigidbody _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    void OnCollisionEnter(Collision col){
        _rb.velocity = Vector3.zero;
    }
