    public static string CreateHMAC(int data, byte[] key)
    {
        using(var hmac = new HMACSHA1(key))
        {
            var dataArray = BitConverter.GetBytes(data);
            var resultArray = hmac.ComputeHash(dataArray);
            return Convert.ToBase64String(resultArray);
        }
    }
