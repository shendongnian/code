    using System;
    
    namespace SOFAcrobatics
    {
        public static class Launcher
        {
            public static void Main ()
            {
                Int32 n = 0;
                Boolean locker = false;
                for (Int32 i = 2 ; i <= 38 ; i+= 2)
                {
                    n = ((i > 20) ? (40 - i) : i);
                    if (n == 20 && !locker)
                    {
                        locker = true;
                        i -= 2;
                    }
                    for (Int32 j = 1; j <= (n / 2); j++)
                    {
                        Console.Write('*');
                    }
                    Console.WriteLine(n);
                }
                Console.ReadKey(true);
            }
        }
    }
