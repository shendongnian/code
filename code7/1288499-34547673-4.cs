    public static string string_to_hex(byte[] ba)
    {
        var hex = new StringBuilder(ba.Length * 2);
        foreach (byte b in ba) {
            hex.AppendFormat("{0:x2}", b);
        }
        return hex.ToString();
    }
