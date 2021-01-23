            int x = 5;
            for (int i = 1; i <= 10; i++)
            {
                Console.ResetColor();
                if (x > 5)
                {
                    Console.Write(new String(' ', x - 5));
                }
                if (i % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                }
                x = x + 1;
                string str = "word";
                Console.WriteLine(str);
            }
            Console.ReadLine();
