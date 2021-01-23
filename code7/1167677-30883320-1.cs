    public string GetSHA1(string input)
    {
        byte[] data = Encoding.UTF8.GetBytes(input);
        using (SHA512 shaM = new SHA512Managed())
        {
            byte[] result = shaM.ComputeHash(data);
            return Convert.ToBase64String(result);
        }
    }
