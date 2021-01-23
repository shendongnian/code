    public Camera YourCamera;
    private Vector3 InitialClickPosition;
    private const int MOUSE_BUTTON = 0;
   
    private void LateUpdate()
    {
        if(Input.GetMouseButtonDown(MOUSE_BUTTON))
        {
            InitialClickPosition = YourCamera.ScreenToWorldPoint(Input.mousePosition);
        }
        else if(Input.GetMouseButton(MOUSE_BUTTON))
        {
            var difference = YourCamera.ScreenToWorldPoint(Input.mousePosition) - YourCamera.transform.position;
            YourCamera.transform.position = InitialClickPosition - difference;
        }
    }
