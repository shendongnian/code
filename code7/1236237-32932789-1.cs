    const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    static string GetRandomString(int length)
    {
        string s = "";
        using (RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider())
        {
            while (s.Length != length)
            {
                byte[] oneByte = new byte[1];
                provider.GetBytes(oneByte);
                char character = (char)oneByte[0];
                if (valid.Contains(character))
                {
                    s += character;
                }
            }
        }
        return s;
    }
