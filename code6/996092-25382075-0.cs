        private void WSControllerForm_Load(object sender, System.EventArgs e)
        {
            ConnectionOptions options = new ConnectionOptions();
            options.Password = "password";
            options.Username = "Administrator";
            //i'm not 100% sure these 4 lines are needed - try without if it still fails
            options.Impersonation =
                System.Management.ImpersonationLevel.Impersonate;
            options.EnablePrivileges = true;
            options.Authority = "NTLMDOMAIN:RTOKEN-SERVER";
            options.Authentication = AuthenticationLevel.PacketPrivacy;
            ManagementScope scope =
                new ManagementScope(@"\\RTOKEN-SERVER\root\cimv2", options);
            scope.Connect();
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher();
            moSearcher.Scope = scope;
            moSearcher.Query = new ObjectQuery("SELECT * FROM win32_Service WHERE Name ='Recharger Token'");
            ManagementObjectCollection mbCollection = moSearcher.Get();
            foreach (ManagementObject oReturn in mbCollection)
            {
                //invoke start
                //ManagementBaseObject outParams = oReturn.InvokeMethod("StartService", null, null);
                //invoke stop
                //ManagementBaseObject outParams = oReturn.InvokeMethod("StopService", null, null);
                //get result
                //string a = outParams["ReturnValue"].ToString();
                //get service state
                string state = oReturn.Properties["State"].Value.ToString().Trim();
                MessageBox.Show(state);
            }
        }
