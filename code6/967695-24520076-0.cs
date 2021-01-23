    static void Main(string[] args)
    {
        foreach (int i in Read(Console.In))
        {
            Console.WriteLine(i);
        }
    }
    static IEnumerable<int> Read(TextReader rdr)
    {
        int ch;
        bool neg = false;
        int value = 0;
        int count = 0;
        while (-1 != (ch = rdr.Read()))
        {
            if (ch == 9 || ch == 10 || ch == 13 || ch == 32)
            {
                if (count > 0)
                    yield return neg ? -value : value;  
                count = 0;
                value = 0;
                neg = false;
            }
            else if (count == 0 && ch == '-')
            {
                neg = true;
            }
            else if (ch >= '0' && ch <= '9')
            {
                count++;
                value = value*10 + (ch - '0');
            }
            else
                throw new InvalidDataException();
        }
        if (count > 0)
            yield return neg ? -value : value;  
    }
