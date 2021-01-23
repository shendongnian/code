    public static string Encrypt(string content)
    {
       MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
       byte[] bytes = Encoding.ASCII.GetBytes(content);
       bytes = md5.ComputeHash(data);
       string result = Encoding.ASCII.GetString(bytes);
       return result;
    }
