     public override int SaveChanges()
        {
            //Get Modified Entities
            var modifiedEntries = ChangeTracker.Entries()
                 .Where(x => x.Entity is ITableData
                     && (x.State == EntityState.EntityState.Modified));
            foreach (var entry in modifiedEntries)
             {
               var entity = entry.Entity as ITableData;
               //Modify updateddate
               if (entity != null)
                {
                  entity.UpdatedDate = DateTime.UtcNow;
                }
             }
            return base.SaveChanges();
        }
