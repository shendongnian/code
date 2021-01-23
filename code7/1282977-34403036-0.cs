    public float interval = 1; // 1 second between intervals starting off
    public float speed = 2; // the starting speed
    
    Rigidbody2D _rb;
    
    void Start () {
        // move left
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.left * speed;
        StartCoroutine("IncreaseSpeedWithInterval");
    }
    
    void Update () {
    
    }
    
    IEnumerator IncreaseSpeedWithInterval()
    {
        while(true){
        yield return new WaitForSeconds(interval);
        // Now either Multiply your velocity by 1.01f or Add by 0.01f
        _rb.velocity *= 1.01f;
        // ========== OR ========== //
        _rb.velocity += (Vector2.one * 0.01f);
        }
    }
