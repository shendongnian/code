     // Find the PasswordCredential for a user with a specified resource
            private PasswordCredential FindCredentialsForResourceAndUsername(string resource,
            string username)
            {
                try
                {
                    PasswordVault vault = new PasswordVault();
                    IReadOnlyList<PasswordCredential> credentials =
                    vault.FindAllByResource(resource);
                    foreach (var credential in (IEnumerable<PasswordCredential>)credentials)
                    {
                        if (credential.UserName.Equals(username))
                        {
                            return credential;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle the error
                }
                return null;
    }
