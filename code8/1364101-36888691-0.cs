    string GetBits(string input)
    {
        StringBuilder sb = new StringBuilder();
        foreach (byte b in Encoding.UTF8.GetBytes(input))
        {
            Console.WriteLine(b);
            string temp = Convert.ToString(b, 2);
            temp = "00000000".Substring(temp.Length) + temp; 
            Console.WriteLine(temp);
            sb.Append(temp);
        }
        return sb.ToString();
    }
