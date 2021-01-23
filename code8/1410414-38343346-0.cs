    var obj = new MyClass();
    
    foreach (var prop in obj.GetType().GetProperties())
    {
        Console.WriteLine($"Name = {prop.Name} ** Type = { prop.PropertyType}");
    }
