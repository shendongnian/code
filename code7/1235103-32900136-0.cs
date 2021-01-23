    void FixedUpdate()
    {
        if (Handle.ToInt32() == 0)
        {
            Handle = GetActiveWindow();
            System.UInt32 uP;
            GetWindowThreadProcessId(Handle, out uP);
            System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById((int)uP);
            if (string.Equals(p.ProcessName, "Unity"))
                AllowReset = false;
            else if (string.Equals(p.ProcessName, "TestBuild00001"))
                AllowReset = true;
            else
                Handle = new IntPtr(0);
        }
    }
    void Update()
    {
            if (ScreenSet && AllowReset && GuiValidReset)
        {
            GuiValidReset = false;
            ScreenSet = false;
            SetPosition();
        }
    }
    void OnGUI()
    {
        if (ScreenSet && AllowReset && !GuiValidReset)
            GuiValidReset = true;
    }
    
    internal static void SetPosition()
    {
            SetWindowPos(StartMenu.Handle, 0, 0, 0, 0, 0, 0x0001);
    }
