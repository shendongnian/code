    public string GetHash(string secret, string salt = null)
    {
      var hasher = SHA256Managed.Create();
      salt = salt ?? Guid.NewGuid().ToString("N"); // 128 bit salt 
      var hashResult = hasher.ComputeHash(Encoding.UTF8.GetBytes(salt+"|"+what));
      return "SHA256|" + salt + "|" + Convert.ToBase64String(hashResult);
    }
