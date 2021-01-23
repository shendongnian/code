    public bool platformTouch;  //true or false if touching platform
    public Transform groundCheck; //Object which will check if we are grounded
    public bool groundedTouch; //true or false if touching ground
    public LayerMask ground; //Decide which layers count as grounded.
    float groundRadius = .2f;  //Radius around ground check object will check if grounded
    public LayerMask platform; //Decide which layers count as grounded.
    void FixedUpdate()
    {
        platformTouch = Physics2D.OverlapCircle(groundCheck.position, groundRadius, platform);
        groundedTouch = Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground);
    }
