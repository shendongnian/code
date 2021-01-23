    db.ChangeTracker.Entries()
                    .Where(x => x.State == EntityState.Modified &&
                                x.Entity.GetType() != typeof(YourSpecialEntity))
                    .ToList()
                    .ForEach(entry => {
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                    });
    db.SaveChanges();
