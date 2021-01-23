        private static ClientContext GetContext(string url,string username, string password)
        {
            var ctx = new ClientContext(url);
            var securePassword = new SecureString();
            foreach (char c in password) securePassword.AppendChar(c);
            ctx.Credentials = new SharePointOnlineCredentials(username, securePassword);
            return ctx;
        }
