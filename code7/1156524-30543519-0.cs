    public static class Extension
    {
        public static T Dump<T>(this T tObject)
        {
            tObject.GetType()
           		   .GetProperties()
           		   .Where(property => property.GetValue(tObject) != null)
           	       .Select(property => string.Format("{0}: {1}", property.Name, property.GetValue(tObject)))
			 	   .ToList()
				   .ForEach(Console.WriteLine);
        	
			return tObject;
		}
    }
