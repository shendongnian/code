    static string GetColor(string raw)
    {
        using (MD5 md5Hash = MD5.Create())
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(raw));
            return BitConverter.ToString(data).Replace("-", string.Empty).Substring(0, 6);
        }
    }
