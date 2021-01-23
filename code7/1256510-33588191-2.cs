    public static string bigToLittle(string data)
    {
        long sValueAsInt = long.Parse(data, System.Globalization.NumberStyles.HexNumber);
        byte[] bytes = BitConverter.GetBytes(sValueAsInt);
        string retval = "";
        foreach (byte b in bytes)
            retval += b.ToString("X2");
        return retval; //output {652E47D2F9EEAB8B}
    }
