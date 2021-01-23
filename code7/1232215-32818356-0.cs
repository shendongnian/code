      c = star % 2 == 0? 0:1;
----------
        int num;
        Console.WriteLine("enter level");
        num = Int32.Parse(Console.ReadLine());
        int count = 1;
        int c = 0;
        for (int lines = num; lines >= 1; lines--)
        {
            for (int spaces = lines - 1; spaces >= 1; spaces--)
            {
                Console.Write(" ");
            }
            for (int star = 1; star <= count; star++)
            {
                c = star % 2 == 0? 0:1;
                Console.Write(c);
                Console.Write(" ");
            }
            count++;
            Console.WriteLine();
        }
        Console.ReadLine();
