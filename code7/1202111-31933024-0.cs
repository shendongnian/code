    Console.WriteLine("Before impersonation: " + identity.Name);
    Console.WriteLine("ImpersonationLevel: {0}", identity.ImpersonationLevel);
    // Use the token handle returned by LogonUser. 
    using (WindowsIdentity newId = new   
           WindowsIdentity(safeTokenHandle.DangerousGetHandle()))
    {
	    using (WindowsImpersonationContext impersonatedUser = newId.Impersonate())
	    {
		    // Check the identity.
   		    identity = WindowsIdentity.GetCurrent();
		    Console.WriteLine("After impersonation: "+ identity.Name);
		    Console.WriteLine("ImpersonationLevel: {0}", identity.ImpersonationLevel);
	    }
    }
