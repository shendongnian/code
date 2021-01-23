    static void Main(string[] args)
    {
        List<char> chars = new List<char> {'A', 'E', 'L', 'L', 'O'};
        foreach (var c in chars)
        {
            string s = "";
            for (int i = 0; i < (sizeof(char) * 8); i++)
            {
                s = (1 & ((byte)c >> i)) + s;
            }
            Console.WriteLine("{0} represents {1}",c,s );
        }
        Console.Read();
    }
