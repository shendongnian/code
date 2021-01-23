    Classtest testclass = new Classtest();
    var propertyInfo = testclass.GetType().GetProperties(System.Reflection.BindingFlags.DeclaredOnly);
    
    
    foreach (var p in propertyInfo)
    {                  
        Console.WriteLine(p.Name);
    }
