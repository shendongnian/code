     public override int SaveChanges()
        {
            //Get Added Entities
            var addedEntries = ChangeTracker.Entries()
                 .Where(x => x.Entity is ITableData
                     && (x.State == EntityState.Added));
            foreach (var entry in addedEntries)
             {
               var entity = entry.Entity as ITableData;
               //Create new guid
               if (entity != null)
                {
                  entity.Id = Guid.NewGuid().ToString();
                }
             }
            return base.SaveChanges();
        }
