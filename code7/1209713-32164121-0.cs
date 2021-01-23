    // first call
    using (var dbContext = new CustomDbContext())
    {
        foreach (var item in dbContext.Items.Take(2000000))
        {
            // perform conversion tasks...
            item.Converted = true;
        }
    }
    
    // second call
    using (var dbContext = new CustomDbContext())
    {
        foreach (var item in dbContext.Items.Take(2000000))
        {
            // perform conversion tasks...
            item.Converted = true;
        }
    }
