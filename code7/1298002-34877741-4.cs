    using System;
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Codepoints:");
            for (int cur = Console.Read(); cur != -1; cur = Console.Read())
                Console.WriteLine("U+{0:X4}", cur);
        }
    }
