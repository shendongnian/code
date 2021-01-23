     var myEntityModel = new MyEntityModel(); //your context
     var dbSets = myEntityModel.GetType().GetProperties().Where(p => p.PropertyType.Name.StartsWith("DbSet")); //get Dbset<T>
     foreach (var dbSetProps in dbSets)
     {
         var dbSet = dbSetProps.GetValue(myEntityModel, null);
         var dbSetType = dbSet.GetType().GetGenericArguments().First();
         var classNameProp = dbSetType.GetProperty("className");// i did not undestand, you want classes with className property?
         if (classNameProp != null)
         {
             var contents = ((IEnumerable) dbSet).Cast<object>().ToArray();//Get The Contents of table
         }
