    List<Task> tasks = new List<Task>();
    tasks.Add(Task.Factory.StartNew(() =>
    {
        using (dbContext = new DatabaseContext())
        {
            return dbContext.Where(r => r.Id = 100).ToListAsync().ContinueWith(t =>
                {
                    var records = t.Result;
                    // do long cpu process here...
                });
            }
        }
    }
