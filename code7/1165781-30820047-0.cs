        void Something()
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(ReadAsync());
            Task.WaitAll(tasks.ToArray());
        }
        async Task ReadAsync() {
            using (dbContext = new DatabaseContext())
            {
                var records = await dbContext.Where(r => r.Id = 100).ToListAsync();
                //do long cpu process here...
            }
        }
