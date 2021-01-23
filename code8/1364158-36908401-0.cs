        int SaveChangesWithDelete(int userId)
        {
            using (var tx= Database.BeginTransaction()) //Begin a new transaction
            {
                var entitiyGroups = ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Deleted && e.Entity is Auditable)
                    .Select(e => e.Entity)
                    .GroupBy(d => d.GetType();
                foreach (var entityGroup in entitiyGroups) //Loop through deleted entities and run a manual UPDATE 
                {
                    string query = string.Format(@"
                        UPDATE {0} SET UpdatedBy = {1}
                        WHERE Id IN ({2})
                    ", entityGroup.Key.Name, userId, string.Join(",", entityGroup.Select(e => PrimaryKeyValue(e))));
                    Database.ExecuteSqlCommand(query); //Execute the query - this triggers the audit framework
                }
                int result = SaveChanges();     //save the context changes as normal
                tx.Commit();                    //commit the transaction
                return result;                  //return the result
            } 
        }
