    var computerName = "IP_ADDRESS";
            ConnectionOptions conn = new ConnectionOptions();
            conn.Username = "username";
            conn.Password = "password";
            conn.Authority = "ntlmdomain:DOMAIN";
            conn.Impersonation = ImpersonationLevel.Impersonate;
            conn.EnablePriviledges = true;
            var scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", computerName), conn);
            scope.Connect();
            string Drive = "c:";
            string Path = "\\\\inetpub\\\\wwwroot\\\\FOLDER\\\BIN\\\File.dll";
            ObjectQuery Query = new ObjectQuery(string.Format("SELECT * FROM CIM_DataFile Where Drive='{0}' AND Path='{1}' ", Drive, Path));
            ManagementObjectSearcher Searcher = new ManagementObjectSearcher(scope, Query);
            foreach (ManagementObject WmiObject in Searcher.Get())
            {
                Console.WriteLine("{0}", (string)WmiObject["Name"]);// String
            }
