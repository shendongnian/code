    string GetBits(string input)
    {
        StringBuilder sb = new StringBuilder();
        foreach (byte b in Encoding.UTF8.GetBytes(input))
        {
            string temp = Convert.ToString(b, 2);
            // This ensure that 8 chars represent the 8bits
            temp = "00000000".Substring(temp.Length) + temp; 
            sb.Append(temp);
        }
        return sb.ToString();
    }
