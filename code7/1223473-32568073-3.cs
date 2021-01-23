    public static byte[] HexToBytesv2(string hex)
    {
        if (hex.Length % 2 == 1)
            hex = '0' + hex;
    
        byte[] ret = new byte[hex.Length / 2];
    
        for (int i = 0; i < ret.Length; i++)
            ret[i] = Convert.ToByte(hex.Substring(hex.Length - (i+1) * 2, 2), 16);
    
        return ret;
    
    }
    
    public static string ToHex( byte[] bytes)
    {
        var sb = new StringBuilder();
        foreach (var b in bytes.Reverse())
        {
            sb.AppendFormat("{0:x2}", b);
        }
        return sb.ToString();
    }
