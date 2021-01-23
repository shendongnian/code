    private Rigidbody2D _rigidBody;
    
    void Start()
    {
    	_rigidBody = GetComponent<Rigidbody2D>();
    }
    
    void  Update ()
    {
        float xVel = _rigidBody.velocity.x;
        if( xVel < 18 && xVel > -18 && xVel !=0){
            if(xVel > 0){
                _rigidBody.velocity = new Vector2(20, _rigidBody.velocity.y);   
    
            }else{
                _rigidBody.velocity = new Vector2(-20, _rigidBody.velocity.y);   
            }
        }
    }
