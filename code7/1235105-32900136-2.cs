    void FixedUpdate()
    {
        if (Handle == IntPtr.Zero)
        {
            Handle = GetActiveWindow();
            uint uP;
            GetWindowThreadProcessId(Handle, out uP);
            System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById((int)uP);
            if (string.Equals(p.ProcessName, "Unity"))
                AllowReset = false;
            else if (string.Equals(p.ProcessName, "TestBuild00001"))
                AllowReset = true;
            else
                Handle = IntPtr.Zero;
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
