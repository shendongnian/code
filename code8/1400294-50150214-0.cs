    private void RemoveAllCredentials(PasswordVault passwordVault)
        {
            //Get all credentials.
            List<PasswordCredential> passwordCredentials = new List<PasswordCredential>();
            var credentials = passwordVault.RetrieveAll();
            foreach (PasswordCredential credential in credentials)
            {
                if (credential.Resource.Equals("ResourceName"))
                {
                    passwordCredentials.Add(
                        passwordVault.Retrieve(credential.Resource, credential.UserName));
                }
            }
            foreach (PasswordCredential entry in passwordCredentials)
            {
                passwordVault.Remove(entry);
            }
        }
