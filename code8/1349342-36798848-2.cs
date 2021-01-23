        static void Main(string[] args)
                {
                    using (Entities entities = new Entities())
                    {
                        try
                        {
                            //code goes here
                            entities.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            syncResult = string.IsNullOrEmpty(e.Message) ? "Error" : e.Message;
                            // If we get error clear context.
                            ClearEntities();
                        }
                        
                        entities.LogHistories.Add(new LogHistory() { Description = syncResult });
                        entities.SaveChanges();
                    }
                }       
         public static IEnumerable<ObjectStateEntry> GetAllObjectStateEntries()
            {
                return ObjectStateManager.GetObjectStateEntries(EntityState.Added |
                                                            EntityState.Deleted |
                                                            EntityState.Modified |
                                                            EntityState.Unchanged);
            }
    
          public static void ClearEntities()
            {
                foreach (var objectStateEntry in GetAllObjectStateEntries())
                {
                    Detach(objectStateEntry.Entity);
                }
            }
    
