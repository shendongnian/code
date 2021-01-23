    Classtest testclass = new Classtest();
    var propertyInfo = testclass.GetType().GetProperties();
    
    
    foreach (var p in propertyInfo)
    {                  
        Console.WriteLine(p.Name);
    }
