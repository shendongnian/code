    public void Test()
    {
        var password = "somepassword";
        var encrypted_password = EncryptPassword(password);
        var decrypted_password = DecryptPassword(encrypted_password);
    }
    public string EncryptPassword(string password)
    {
        var data = Encoding.UTF8.GetBytes(password);
        var encrypted_data = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
        return Convert.ToBase64String(encrypted_data);
    }
    public string DecryptPassword(string encrypted_password)
    {
        var encrypted_data = Convert.FromBase64String(encrypted_password);
        var data = ProtectedData.Unprotect(encrypted_data, null, DataProtectionScope.CurrentUser);
        return Encoding.UTF8.GetString(data);
    }
