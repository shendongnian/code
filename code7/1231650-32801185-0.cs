    static void Main(string[] args)
    {
    	string fileName = Path.Combine(Directory.GetCurrentDirectory(), "All Polished.mp4");
    	ShellObject shellObject= ShellObject.FromParsingName(fileName);
    	PropertyInfo[] propertyInfos = shellObject.Properties.System.GetType().GetProperties();
    	foreach (var propertyInfo in propertyInfos)
    	{
    		object value = propertyInfo.GetValue(shellObject.Properties.System, null);
    
    		if (value is ShellProperty<int?>)
    		{
    			var nullableIntValue = (value as ShellProperty<int?>).Value;
    			Console.WriteLine($"{propertyInfo.Name} - {nullableIntValue}");
    		}
    		else if (value is ShellProperty<ulong?>)
    		{
    			var nullableLongValue =
    				(value as ShellProperty<ulong?>).Value;
    			Console.WriteLine($"{propertyInfo.Name} - {nullableLongValue}");
    		}
    		else if (value is ShellProperty<string>)
    		{
    			var stringValue =
    				(value as ShellProperty<string>).Value;
    			Console.WriteLine($"{propertyInfo.Name} - {stringValue}");
    		}
    		else if (value is ShellProperty<object>)
    		{
    			var objectValue =
    				(value as ShellProperty<object>).Value;
    			Console.WriteLine($"{propertyInfo.Name} - {objectValue}");
    		}
    		else
    		{
    			Console.WriteLine($"{propertyInfo.Name} - Dummy value");
    		}
    	}
    	Console.ReadLine();
    }
