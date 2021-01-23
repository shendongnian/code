    var type = typeof(IExample<int, double>);
    var arguments = Type.GetGenericArguments(type);
    if(arguments.Any())
    {
    	var name = argument.Name.Replace("'" + arguments.Length);
    	Console.Write(name + "<");
    	foreach(var argument in arguments)
    	{
    		Console.Write(argument.Name);
    		if(argument != arguments.Last())
    		{
    			Console.Write(", ");
    		}		
    	}
    	Console.WriteLine(">")
    }
    else
    {
    	Console.WriteLine(type.Name);
    }
