    void Update () 
    {
    var reverseDeltaTime = Time.deltaTime;
    if (Input.GetKey(KeyCode.DownArrow))
    reverseDeltaTime = -reverseDeltaTime;
    if(Input.GetKey(KeyCode.UpArrow))
        transform.Translate(Vector3.forward*speed*reverseDeltaTime);
    if(Input.GetKey(KeyCode.LeftArrow))
        transform.Rotate(0,-90*Time.deltaTime,0);
    if(Input.GetKey(KeyCode.RightArrow))
        transform.Rotate(0,90*Time.deltaTime,0);
    if(Input.GetKey(KeyCode.DownArrow))
        transform.Translate(Vector3.back*speed*reverseDeltaTime);
    if (Input.GetKey(KeyCode.Escape))
        Application.LoadLevel("Menu");
    }
