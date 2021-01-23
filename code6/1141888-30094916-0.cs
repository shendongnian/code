    public string GenerateHash(string str)
    {
        using (var md5Hasher = MD5.Create())
        {
            var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(str));
            return BitConverter.ToString(data).Replace("-", "").Substring(0, 16);
        }
    }
