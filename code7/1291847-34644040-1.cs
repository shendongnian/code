    public static bool VerifyHMAC(int data, byte[] key, string verification)
    {
        using(var hmac = new HMACSHA1(key))
        {
            var dataArray = BitConverter.GetBytes(data);
            var computedHash = hmac.ComputeHash(dataArray);
            var verificationHash = Convert.FromBase64String(verification);
            for (int i = 0; i < storedHash.Length; i++)
            {
                if (computedHash[i] != verificationHash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
