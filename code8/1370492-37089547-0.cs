    void Update()
    {
        rotateCamera();
    }
    
    
    public float xSensitivity = 100.0f;
    public float ySensitivity = 100.0f;
    
    public float yMinLimit = -45.0f;
    public float yMaxLimit = 45.0f;
    
    public float xMinLimit = -360.0f;
    public float xMaxLimit = 360.0f;
    
    float yRot = 0.0f;
    float xRot = 0.0f;
    
    void rotateCamera()
    {
        xRot += Input.GetAxis("Mouse X") * xSensitivity * Time.deltaTime;
        yRot += Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;
        yRot = Mathf.Clamp(yRot, yMinLimit, yMaxLimit);
        Camera.main.transform.localEulerAngles = new Vector3(-yRot, xRot, 0);
    
    }
