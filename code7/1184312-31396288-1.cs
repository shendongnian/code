         using (var dbCtx = new YourDBEntities())
         {
            var yourEntity = dbCtx.YourEntity.Find(1);
            var entry = dbCtx.Entry(yourEntity);
            foreach (var propertyName in entry.CurrentValues.PropertyNames )
            {
               Console.WriteLine("Property Name: {0}", propertyName);
               var originalVal = entry.OriginalValues[propertyName];
               Console.WriteLine("Original Value: {0}", originalVal);
               var currentVal = entry.CurrentValues[propertyName];
               Console.WriteLine("Current Value: {0}", currentVal);
            }
         }
 
