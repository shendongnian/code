    public string FromBytesToBase64(this byte[] b)
    {
        return b == null ? "" :  Convert.ToBase64String(b);
    }
    public byte[] FromBase64ToBytes(this string s)
    {
        return s == null ? null : Convert.FromBase64String(s);
    }
