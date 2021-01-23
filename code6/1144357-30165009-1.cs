    try
    {
    	using (var db = new MyContext())
    	{
            //db.myDataSet.Take(0).SingleOrDefault(); //The following reflection achieves what this line would do
    		var t = db.GetType();
    		var props = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
    		foreach (var prop in props)
    		{
                if (!prop.PropertyType.Name.StartsWith("DbSet"))
                    continue;
    			var getMethod = prop.GetMethod;
    			var dataSet = getMethod.Invoke(db, null);
    			var dataSetType = dataSet.GetType();
    			var queryableType = typeof(Queryable);
    			var takeMethod = queryableType.GetMethod("Take");
    			takeMethod = takeMethod.MakeGenericMethod(dataSetType.GenericTypeArguments);
    			var takeResult = takeMethod.Invoke(null, new object[] { dataSet, 0 });
    			var sodMethod = queryableType.GetMethods().Where(m => m.Name == "SingleOrDefault" && m.GetParameters().Length == 1).Single();
    			sodMethod = sodMethod.MakeGenericMethod(dataSetType.GenericTypeArguments);
    			var finalResult = sodMethod.Invoke(null, new object[] { takeResult });
    		}
    	}
    }
    catch (Exception ex)
    {
    	if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.StartsWith("Invalid column"))
    	{
    		MyHelperFunctions.MarkDatabaseForReset();
    	}
    	else
    		throw; //Show error to user - we didn't expect this one
    }
