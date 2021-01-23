    public static string ConstantLengthHash(this string Input)
    {
        const string chars = "234679ACDEFGHJKLMNPQRTUVWXYZ";
        byte[] bytes = Encoding.UTF8.GetBytes(Input);
        SHA256Managed hashstring = new SHA256Managed();
        byte[] hash = hashstring.ComputeHash(bytes);
        char[] hash2 = new char[16];
        // Note that here we are wasting bits of hash! 
        // But it isn't really important, because hash.Length == 32
        for (int i = 0; i < hash2.Length; i++)
        {
            hash2[i] = chars[hash[i] % chars.Length];
        }
        return new string(hash2);
    }
