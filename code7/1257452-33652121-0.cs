     public SaveConfigurations(List<Configuration> configs)
        {
            try
            {
               
                using (var dc = new ConfigContext())
                {
                   dc.Configuration.AutoDetectChangesEnabled = false;
                   foreach(var singleConfig in configs)
                   {
                     //Donot invoke dc.SaveChanges on the loop.
                     //Assuming the SaveConfiguration is your table.
                     //This will add the entity to DbSet<T> , Will not insert to Db until you invoke SaveChanges
                     dc.SaveConfiguration.Add(singleConfig);
                   } 
                   dc.Configuration.AutoDetectChangesEnabled = true;
                   dc.SaveChanges();
                }
                
            }
            catch (Exception exception)
            {
               throw exception
            }
        }
