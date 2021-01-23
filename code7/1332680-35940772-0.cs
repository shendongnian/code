    static void Main(string[] args)
        {
            string a = "a";
            for (int i = 0; i < 100; i++)
            {
                Console.Clear();
                Console.Write(a);
                a = " " + a;
                System.Threading.Thread.Sleep(100);
            }
        }
