    public void Start() 
    {
        MyRigidBody = gameObject.GetComponent<Rigidbody>();
        if(Controls.Length < 4)
            throw new System.Exception("Controls not assigned correctly");
        
        DoSomethingElse();
    }
    protected virtual void DoSomethingElse()
    {
        //can be empty in base class, derived classes provide the implementation
    }
