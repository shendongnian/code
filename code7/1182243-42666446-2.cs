            public void OnBeforeSaveChanges(DbContext dbContext)
        {
            foreach (var dbEntityEntry in dbContext.ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
            {
                IConcurrencyEnabled entity = dbEntityEntry.Entity as IConcurrencyEnabled;
                if (entity != null)
                {
                    if (dbEntityEntry.State == EntityState.Added)
                    {
                        var rowversion = dbEntityEntry.Property("RowVersion");
                        rowversion.CurrentValue = BitConverter.GetBytes((Int64)1);
                    }
                    else if (dbEntityEntry.State == EntityState.Modified)
                    {
                        var valueBefore = new byte[8];
                        System.Array.Copy(dbEntityEntry.OriginalValues.GetValue<byte[]>("RowVersion"), valueBefore, 8);
                        
                        var value = BitConverter.ToInt64(entity.RowVersion, 0);
                        if (value == Int64.MaxValue)
                            value = 1;
                        else value++;
                        var rowversion = dbEntityEntry.Property("RowVersion");
                        rowversion.CurrentValue = BitConverter.GetBytes((Int64)value);
                        rowversion.OriginalValue = valueBefore;//This is the magic line!!
                        
                    }
                    
                }
            }
        }
