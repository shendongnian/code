    string CredentialsName = "testing";
    private PasswordCredential GetCredentialFromLocker()
    {
        PasswordCredential credential = null;
        var vault = new PasswordVault();
        IReadOnlyList<PasswordCredential> credentialList = null;
        try
        {
            credentialList = vault.FindAllByUserName(Username);
        }
        catch
        {
            return credential;
        }
        if (credentialList.Count > 0)
        {
            credential = credentialList[0];
        }
        return credential;
    }
    public void CreatePassword(string password, string username)
    {
        var vault = new PasswordVault();
        vault.Add(new PasswordCredential(CredentialsName, username, password));
    }
