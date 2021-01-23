        Random random = new Random(DateTime.Now.Milliseconds);
        using (var context = new Data.Entities())
        {
            var entries = context.YourTable;
 
            foreach (var entry in entries ) 
            {
               entry.YourColumn = random.Next(100);
            }
            context.SaveChanges();
        }
