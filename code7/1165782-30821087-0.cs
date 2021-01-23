    List<Task> tasks = new List<Task>();
    tasks.Add(Task.Factory.StartNew(async () =>
    {
        using (dbContext = new DatabaseContext())
        {
            var records = await dbContext.Where(r => r.Id = 100).ToListAsync();
            //do long cpu process here...
        }
    }).Unwrap());
