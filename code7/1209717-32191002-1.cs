    private static void Debug()
    {
        var iteration = 0;
        while(true)
        {
            Console.WriteLine("Iteration {0}", iteration++);
            using (var dbContext = new CustomDbContext(args[0]))
            {
                // OutOfMemoryException in second iteration
                var list = dbContext.Items.Take(2000000).ToList(); 
                foreach (var item in list)
                {
                    item.Converted = true;
                }
            }
        }
    }
