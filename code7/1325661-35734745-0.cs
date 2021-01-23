    DSAParameters keys;
    var DSAalg = new DSACryptoServiceProvider();
    keys = DSAalg.ExportParameters(true);
    byte[] bytes = keys.G;
    if ((bytes[bytes.Length - 1] & 0x80) > 0)
    {
        var temp = new byte[bytes.Length];
        Array.Copy(bytes, temp, bytes.Length);
        bytes = new byte[temp.Length + 1];
        Array.Copy(temp, bytes, temp.Length);
    }
    Console.WriteLine("G is {0} \n", new BigInteger(bytes));
