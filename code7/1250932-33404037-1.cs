    db.ChangeTracker.Entries()
                    .Where(x => x.State == EntityState.Modified &&
                                !typeof(YourSpecialEntity).IsAssignableFrom(x.Entity.GetType()))
                    .ToList()
                    .ForEach(entry => {
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                    });
    db.SaveChanges();
