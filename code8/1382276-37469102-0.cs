    public void unmapPrinter()
    {
        ConnectionOptions options = new ConnectionOptions();
        options.EnablePrivileges = true;
        ManagementScope scope = new ManagementScope(ManagementPath.DefaultPath, options);
        scope.Connect();
        ManagementClass win32Printer = new ManagementClass("Win32_Printer");
        ManagementObjectCollection printers = win32Printer.GetInstances();
        foreach (ManagementObject printer in printers)
        {
            printer.Delete();
        }
    }
