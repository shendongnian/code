    public byte[] Derive48(String passphrase, byte[] salt)
    {
        using (var md5 = new MD5CryptoServiceProvider())
        {
            var source = Encoding.UTF8.GetBytes(passphrase).Concat(salt).ToArray();
            var data = md5.ComputeHash(source);
            var output = data;
            while (output.Length < 48)
            {
                data = md5.ComputeHash(data.Concat(source).ToArray());
                output = output.Concat(data).ToArray();
            }
            return output.Take(48).ToArray();
        }
    }
