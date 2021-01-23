    public class MyDbContext : DbContext
     {
         /// <summary>
         /// Execute the 'Load' method for every DbSet<> property in the current DbContext
         /// </summary>
         public void LoadAll()
         {
             // Get all properties which should be loaded
             var propreties = typeof(FrameworkDbContext).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                 .Where(Item => Item.PropertyType.IsGenericType && Item.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>)).ToList();
    
             // Get method which will be exeecuted for every property (Extension method)
             var loadMethod = typeof(QueryableExtensions)
                                  .GetMethods(BindingFlags.Static | BindingFlags.Public)
                                  .Where(mi => mi.Name == "Load").FirstOrDefault(); 
    
    
             if (loadMethod != null)
             {
                 foreach (var property in propreties)
                 {
                     var value = property.GetValue(this);
    
                     // Execute load method
                     loadMethod.Invoke(value, new object[] { value });
                 }
             }
         }
    }
