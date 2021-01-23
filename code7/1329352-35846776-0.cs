    void Update()
    {
    if (!EventSystem.current.IsPointerOverGameObject())
        {     
        if(Input.GetAxis("Mouse ScrollWheel")<0)
            {
                CameraZoom();
            }
        }
    }
