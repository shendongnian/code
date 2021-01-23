    string GetString(string input)
    {
        StringBuilder sb = new StringBuilder();
        while (input.Length > 0)
        {
            string block = input.Substring(0, Math.Min(8, input.Length));
            input = input.Substring(Math.Min(8, input.Length));
            int value = 0;
            foreach (int x in block)
            {
                int temp = x - 48;
                value = (value << 1) | temp;
                Console.WriteLine(value);
            }
            sb.Append(Convert.ToChar(value));
        }
        return sb.ToString();
    }
