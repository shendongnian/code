    string GetString(string input)
    {
        // Probably a checking on the input length as multiple of 8 
        // should be added here....
        StringBuilder sb = new StringBuilder();
        while (input.Length > 0)
        {
            string block = input.Substring(0, 8);
            input = input.Substring(8);
            int value = 0;
            foreach (int x in block)
            {
                int temp = x - 48;
                value = (value << 1) | temp;
            }
            sb.Append(Convert.ToChar(value));
        }
        return sb.ToString();
    }
