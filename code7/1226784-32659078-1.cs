    private void MyMethod(string domain, string userName, string password)
    {
        WindowsIdentity _identity = Win32LogonInterop.LogOn(domain, userName, password);
        WindowsImpersonationContext impersonation = null;
        try
        {
            impersonation = _identity.Impersonate();
            // Stuff that needs impersonation
        }
        finally
        {
            if (impersonation != null)
            {
                impersonation.Undo();
                impersonation.Dispose();
            }
            if (_identity != null)
            {
                Win32LogonInterop.LogOff(_identity);
            }
        }
    }
