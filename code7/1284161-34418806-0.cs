    var ip = "127.0.0.1";
    var scope = new ManagementScope(
        String.Format("\\\\{0}\\root\\cimv2", ip),
        new ConnectionOptions { Impersonation = ImpersonationLevel.Impersonate });
    scope.Connect();
    
    var users = new ManagementObjectSearcher(
        scope,
        new ObjectQuery("Select * from Win32_LoggedonUser"))
            .Get()
            .GetEnumerator();
    
    while(users.MoveNext())
    {
            var user =  users.Current["antecedent"];
            var mo = new ManagementObject(new ManagementPath(user.ToString()));
    
            var username = mo.Properties["name"];
            Console.WriteLine("username {0}", username.Value);
    }
