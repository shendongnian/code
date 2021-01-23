    ConnectionOptions cOption = new ConnectionOptions();
        ManagementScope scope = new ManagementScope("\\\\" + machine + "\\" + nameSpaceRoot + "\\" + managementScope, cOption);
               scope.Options.Username = UserName;
                scope.Options.Password = passWord;
                scope.Options.EnablePrivileges = true;
                scope.Options.Authentication = AuthenticationLevel.PacketPrivacy;
                //scope.Options.Timeout = TimeSpan.FromSeconds(180);
                //cOption.Timeout = TimeSpan.FromSeconds(180);
                scope.Options.Impersonation = ImpersonationLevel.Impersonate;
                scope.Connect();
                return scope;
        
         
        
        if (scope.IsConnected && scope != null)
        {
        query = new ObjectQuery(@"Select * from Win32_SCSIController");
                                searcher = new ManagementObjectSearcher(scope, query); searcher.Options.Timeout = new TimeSpan(0, 0, wbemConnectFlagUseMaxWait);
                                ManagementObjectCollection qWin32_SCSIController = searcher.Get();
        foreach (ManagementObject item in qWin32_SCSIController)
        {    
        <Some code here>
        }
