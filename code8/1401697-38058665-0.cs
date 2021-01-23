	dynamic entity = new ExpandoObject();
	entity.MyID = 1;
	if(entity.GetType() == typeof(ExpandoObject))
	{
		Console.WriteLine("I'm dynamic, use the dictionary");
		var dictionary = (IDictionary<string, object>)entity;
	}
	else
	{
		Console.WriteLine("Not dynamic, use reflection");
	}
