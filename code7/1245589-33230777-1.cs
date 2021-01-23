    var type = typeof(IExample<int, double>);
    var arguments = Type.GetGenericArguments(type);
    if(arguments.Any())
    {
    	var name = argument.Name.Replace("'" + arguments.Length, "");
    	Console.Write(name + "<");
        Console.Write(string.Join(", ", arguments.Select(x => x.Name));    	
    	Console.WriteLine(">")
    }
    else
    {
    	Console.WriteLine(type.Name);
    }
