    var excercises = dayExercise.Exercises.ToList();
    for (int i = 0; i < excercises.Count; i++)
    {
        var unchangedEntity = _dbContext.ChangeTracker.Entries<Exercise>()
             .Where(xy => xy.State == EntityState.Unchanged &&
             xy.Entity.Id == excercises [i].Id).FirstOrDefault();
        if (unchangedEntity == null)
        {
            fitnessDbContext.Entry(excercises[i]).State = EntityState.Unchanged;
        }
        else
        {
            excercises[i] = unchangedEntity.Entity;
        }
    }
