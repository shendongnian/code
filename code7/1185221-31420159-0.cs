    static void PrintDemo(int num)
    {
        if (num < 0 || num % 2 == 0)
        {
            return;//do nothing
        }
        Console.WriteLine("{0}{1}{0}", new string('-', num / 2), new string('*', num + 2));
    
        for (int i = 0; i < num - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('-', num / 2), new string('-', num));
        }
    
        for (int i = 0; i < num; i++)
        {
            var t1 = Math.Abs(num / 2 - i);
            var t2 = t1 * 2 + 1;
            var t3 = (num * 2 + 1 - t1 * 2 - t2) / 2;
            Console.WriteLine(
                "{0}{1}{2}{1}{0}",
                new string('-', t1),
                new string('*', t3),
                new string('-', t2));
        }
    }
