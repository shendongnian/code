    public float BackRotationsSpeed = 100f;
    public float ForwardRotationSpeed = 300f;
    // Use this for initialization        
    void Start () {
    }
    // Update is called once per frame
    void Update () {                                                                            
        if (Input.GetKey (KeyCode.U))
        {
            if (transform.eulerAngles.z > 8.2 && transform.eulerAngles.z < 8.3)          // Checks if sword is in its original location, and if it is swing backwards.
            {       
                transform.Rotate (Vector3.forward, -BackRotationsSpeed * Time.deltaTime);
            }
            if (transform.eulerAngles.z > 70 && transform.eulerAngles.z < 200)           // Checks if sword has reached furthest back point before swining forward + triple the speed swinging forward for extra oomf!
            {
                transform.Rotate (Vector3.forward, ForwardRotationSpeed * Time.deltaTime);  
            }
            if(transform.eulerAngles.z>8.3 && transform.eulerAngles.z<70)                 // Checks if sword has reached furthest forward point in the forward swing, if it is reset the rotation to its origin and wait for next attack command 
            {
                Vector3 temp = transform.rotation.eulerAngles;
                temp.z = 8.21f;
                transform.rotation = Quaternion.Euler(temp);
            }
        }
    }
