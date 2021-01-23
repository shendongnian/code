    static void Main(string[] args)
    {
        try
        {
            string key;
            do
            {
                LoadData();
                Console.WriteLine("Job finish, please check memory");
                Console.WriteLine("Press 0 to exit, press 1 to load more data and check if throw out of memory exception");
                key = Console.ReadLine();
            } while (key == "1");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            Console.ReadKey();
        }
    }
