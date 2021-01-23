    public static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            // First element is the number of times to launch itself
            int numberOfClients = Convert.ToInt32(args[0]);
            // Launch the same application multiple times
            for (int i = 0; i < numberOfClients; i++)
            {
                Process.Start(System.Reflection.Assembly.GetEntryAssembly().Location);
            }
        }
        Console.WriteLine("I've been launched");
        Console.ReadLine();
    }
