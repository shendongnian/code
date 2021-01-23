    public static void PrintList(IEnumerable<object> values)
    {
	    foreach (var obj in values)
	    {
		    string objString = "";
		    foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
		    {
			    string name = descriptor.Name;
			    object value = descriptor.GetValue(obj);
			    objString += string.Format(" {0} = {1} ", name, value);
			
		    }
		    Console.WriteLine(objString);
	    }
    }
