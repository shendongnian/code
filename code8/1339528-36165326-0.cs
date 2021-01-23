    public static long HashSHA512String(string Username, string Password)
    {
        string AllString = Username + Password + DateTime.UtcNow.Minute;
        if (string.IsNullOrEmpty(AllString)) throw new ArgumentNullException();
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(AllString);
        buffer = System.Security.Cryptography.SHA512Managed.Create().ComputeHash(buffer);
        long sum = 0;
        for (var i = 0; i < buffer.Length; i++)
        {
            sum += buffer[i];
        }
        var code = sum % 10000;
        return code;
    }
