    public static string[][] load()
    {
        try
        {
            string[][] data = new[]
            {
                File.ReadAllLines(@"data\Month.txt"),
                File.ReadAllLines(@"data\Year.txt"),
                File.ReadAllLines(@"data\WS1_AF.txt"),
                File.ReadAllLines(@"data\WS1_Rain.txt"),
                File.ReadAllLines(@"data\WS1_Sun.txt"),
                File.ReadAllLines(@"data\WS1_TMin.txt"),
                File.ReadAllLines(@"data\WS1_TMax.txt"),
            };
            Console.WriteLine("Files have been found, press any key to continue");
            Console.ReadKey();
            return data;
        }
        catch (Exception)
        {
            Console.WriteLine("Unable to find files... exiting");
            return null;
        }
    }
