    /// <summary>
    /// Return a string of random hexadecimal values which is 6 characters long and relatively unique.
    /// </summary>
    /// <returns></returns>
    /// <remarks>In testing, result was unique for at least 10,000,000 values obtained in a loop.</remarks>
    public static string GetShortID()
    {
        var crypto = new System.Security.Cryptography.RNGCryptoServiceProvider();
        var bytes = new byte[5];
        crypto.GetBytes(bytes); // get an array of random bytes.      
        return BitConverter.ToString(bytes).Replace("-", string.Empty); // convert array to hex values.
    }
