    class Program
        {
            public static void func(int i)
            {
                if (i % 1000 == 0)
                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss:ff") + " => i : " + i.ToString());
                func(i + 1);
            }
    
            static void Main(string[] args)
            {
                func(0);
                Console.Read();
            }
        }
