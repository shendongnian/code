        public static void SetConnectAsAccount(Site site, string username, string password)
        {
            if (site == null)
            {
                throw new ArgumentNullException("site");
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException("username");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException("password");
            }
            foreach (var app in site.Applications.Where(c => c.Path.Equals("/")))
            {
                try
                {
                    // set the Connect-As Accounts login credentials to the Service Acount
                    var appVirDir = app.VirtualDirectories.Where(c => c.Path.Equals("/")).FirstOrDefault();
                    if (appVirDir != null)
                    {
                        appVirDir.UserName = username;
                        appVirDir.Password = password;
                    }     
                }
                catch (Exception ex)
                {
                    // log your exception somewhere so you know what went wrong
                }
            }
        }
