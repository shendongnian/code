    try
        {
          if (!string.IsNullOrEmpty(user))
          {
            // Call LogonUser to get a token for the user  
            bool loggedOn = LogonUser(user, domain, password,
                            9 /*(int)LogonType.LOGON32_LOGON_NEW_CREDENTIALS*/,
                            3 /*(int)LogonProvider.LOGON32_PROVIDER_WINNT50*/,
            out userHandle);
            if (!loggedOn)
            {
              if (userHandle != IntPtr.Zero)
              {
                CloseHandle(userHandle);
              }
              throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            // Begin impersonating the user  
            impersonationContext = WindowsIdentity.Impersonate(userHandle);
          }
          if (userHandle != IntPtr.Zero)
          {
            CloseHandle(userHandle);
          }
          disposed = false;
        }
        catch
        {
        }
      }
      public void Dispose()
      {
        try
        {
          //Dispose of unmanaged resources.
          Dispose(true);
          // Suppress finalization.
          GC.SuppressFinalize(this);
        }
        catch
        {
        }
      }
      protected virtual void Dispose(bool Disposing)
      {
        // Check to see if Dispose has already been called.
        try
        {
          if (disposed)
            return;
          if (Disposing)
          {
            if (userHandle != IntPtr.Zero)
            {
              CloseHandle(userHandle);
            }
            if (impersonationContext != null)
            {
              //impersonationContext.Undo();
              impersonationContext.Dispose();
            }
          }
          disposed = true;
        }
        catch
        {
        }
      }
