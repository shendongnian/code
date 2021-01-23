     // Provide a resource which will be used to access the credentials later
        private void SaveUserCredentials(string username, string password, string resource)
        {
            try
            {
                PasswordVault vault = new PasswordVault();
                PasswordCredential cred = new PasswordCredential(resource,
                username, password);
                vault.Add(cred);
            }
            catch (Exception ex)
            {
                // Handle the error
            }
        }
