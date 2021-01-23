    void Update () {
        if(Input.GetKey(KeyCode.W))
        transform.Translate(Vector3.forward * Time.deltaTime*speed);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime * speed);
    
        if (Input.GetKey(KeyCode.LeftControl))
            speed = 15f;
    
        LookAround();
        Scope();
        
        JoeFix();
        }
    
    public float fixedFloatingHeightMeters; // set to say 1.4 in the editor
    private void JoeFix()
       {
       Vector3 p = transform.position;
       p.y = fixedFloatingHeightMeters;
       transform.position = p;
       }
