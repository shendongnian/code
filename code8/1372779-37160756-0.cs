    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
    
            for (int i = 0; i < n - 1; i++)
            {
                Console.Write("*");
            }
            for (int i = 0; i < n - 1; i++)
            {
                Console.WriteLine(i == 0 ? "*" : "*" + string.Empty.PadLeft(n - 2) + "*");
    
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write("*");
            }
        }
    }
