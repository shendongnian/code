    IntPtr userHandle = IntPtr.Zero;
        bool loggedOn = LogonUser(
    userName,
    domain,
    password,
    9,
    3,
    out userHandle);
        if (!loggedOn)
          throw new Win32Exception(Marshal.GetLastWin32Error());
        WindowsImpersonationContext impersonationContext = WindowsIdentity.Impersonate(userHandle);
              using (var serviceController = new ServiceController(serviceName, IPaddress))
              {
                //code goes here
              }
              serviceController.Dispose();
              if (userHandle != IntPtr.Zero)
                CloseHandle(userHandle);
              if (impersonationContext != null)
                impersonationContext.Undo();
