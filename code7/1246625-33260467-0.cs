    foreach (Connection cn in cm)
    {
        var properties = cn.GetType()
                           .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                           .Where(i => i.CanRead)
        foreach(var property in properties)
        {
            Console.WriteLine("{0} - {1}", property.Name, property.GetValue(cn));
        }
    }
