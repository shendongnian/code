    static void Main(string[] args)
    {
        List<char> chars = new List<char> {'1', '0', '0', '0', '0','0','1'};
        int t = 0;
        for (int i = 0; i < chars.Count; i++)
        {
            if (chars[i] == '1') t += (int)Math.Pow(2, i);
        }
        Console.WriteLine("{0} represents {1}",t,(char)t );
        Console.Read();
    }
