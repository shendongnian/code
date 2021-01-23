    static void Main(string[] args)
    {
        for (int x = 0; x < 3; x++)
        {
            try
            {
                Console.WriteLine(Limits<int>.Default);
                Console.WriteLine("1");
                Console.WriteLine(Limits<object>.Default);
            }
            catch (TypeInitializationException e)
            {
                Console.WriteLine("TypeInitializationException: " + e.Message);
            }
        }
        Console.ReadKey();
    }
