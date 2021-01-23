    Classtest testclass = new Classtest();
    var propertyInfo = testclass.GetType().GetProperties(System.Reflection.BindingFlags.Public
	| System.Reflection.BindingFlags.Instance
	| System.Reflection.BindingFlags.DeclaredOnly);
    
    
    foreach (var p in propertyInfo)
    {                  
        Console.WriteLine(p.Name);
    }
