    using (var impersonationContext = WindowsIdentity.Impersonate(IntPtr.Zero))
    {
        try
        {
            // this code is now using the application pool indentity
        }
        finally
        {
            if (impersonationContext != null)
            {
                impersonationContext.Undo();
            }
        }
    }
