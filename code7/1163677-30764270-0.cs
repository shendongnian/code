        static void Main()
        {
            int potatoCount = 5;
            for (int i = 1; i <= potatoCount; i++)
            {
                Console.Write(i);
                //Only print 'Potato' when not on last print
                if (i+1 > potatoCount) Console.Write(" potato ");
            }
            Console.ReadLine();
        }
