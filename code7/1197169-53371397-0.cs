    try
    {
        using (var proc = Process.GetCurrentProcess())
        using (var curModule = proc.MainModule)
        {
            var moduleHandle = GetModuleHandle(curModule.ModuleName);
            HookHandle = SetWindowsHookEx(WH_KEYBOARD_LL, IgnoreWin_DOrM, moduleHandle, 0);
        }
        frmForm1 = new frmIGS();
        Application.Run(frmForm1);
    }
    finally
    {
        UnhookWindowsHookEx(HookHandle);
    }
