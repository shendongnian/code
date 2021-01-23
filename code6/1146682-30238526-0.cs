    if (Input.GetMouseButton (1) && (!requireLock || controlLock || Cursor.lockState == CursorLockMode.Locked))
    // If the right mouse button is held, rotation is locked to the mouse
    {
        if (controlLock)
        {
            Screen.lockState = CursorLockMode.Locked;
            Screen.visible = false;
        }
    
        rotationAmount = Input.GetAxis ("Mouse X") * mouseTurnSpeed * Time.deltaTime;
    }
    else
    {
        if (controlLock)
        {
            Screen.lockState = CursorLockMode.None;
            Screen.visible = true;
        }
    } 
