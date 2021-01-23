    private static void Debug()
    {
        var iteration = 0;
        while(true)
        {
            Console.WriteLine("Iteration {0}", iteration++);
            Convert();
        }
    }
    private static void Convert()
    {
        using (var dbContext = new CustomDbContext(args[0]))
        {
            var list = dbContext.Items.Take(2000000).ToList();
            foreach (var item in list)
            {
                item.Converted = true;
            }
        }
    }
