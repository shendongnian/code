    using (var dbContext = new MyDatabase_dataEntities())
    {
        var proceed = true;
        while (proceed)
        {
            // Get net 1000 entities to delete
            var entitiesToDelete = dbContext.achievements
                .Where(x => x.players_data == null)
                .Take(1000)
                .ToList();
    
            dbContext.achievements.RemoveRange(entitiesToDelete);
            dbContext.SaveChanges();
    
            // Proceed if deleted entities during this iteration
            proceed = entitiesToDelete.Count() > 0;
        }
    }
