        string hash;
        using (MD5 md5 = MD5.Create())
        {
            hash = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes("Hello World!")));
        }
        hash = hash.Replace("-", "");
