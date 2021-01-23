    public static int HashSHA512String(string Username, string Password)
    {
        string AllString = Username + Password + DateTime.UtcNow;
        if (string.IsNullOrEmpty(AllString)) throw new ArgumentNullException();
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(AllString);
        buffer = System.Security.Cryptography.SHA512Managed.Create().ComputeHash(buffer);
        int code = 0;
        for (var i = 0; i < buffer.Length; i++)
        {
            code += buffer[i];
            code = code % 10000;
        }
        return code;
    }
