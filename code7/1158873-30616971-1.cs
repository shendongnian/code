    public string GetBits(string input)
    {
        StringBuilder sb = new StringBuilder();
        foreach (byte b in ASCIIEncoding.UTF8.GetBytes(input))
        {
            sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
        }
        return sb.ToString();
    }
