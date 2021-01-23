    private static void Main(string[] args)
    {
        for (int i = 0; i < 200; i++)
        {
            Console.WriteLine("Send ping " + i);
            SendPing();
        }
        Console.WriteLine("All done");
        Console.ReadLine();
    }
