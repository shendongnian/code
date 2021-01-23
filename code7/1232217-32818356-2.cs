      c = star % 2;        // will print first the '1'
      c = (star + 1) % 2;  // will print first the '0'
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
                c = star % 2; //this will return 1 if value of start is odd then 0 if even
                Console.Write(c);
                Console.Write(" ");
            }
            count++;
            Console.WriteLine();
        }
        Console.ReadLine();
