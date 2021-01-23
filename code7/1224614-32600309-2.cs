    // using System.Reflection;
    foreach (var property in dbEntry.Entity.GetType().GetTypeInfo().DeclaredProperties)
    {
        var originalValue = dbEntry.Property(property.Name).OriginalValue;
        var currentValue = dbEntry.Property(property.Name).CurrentValue;
        Console.WriteLine($"{property.Name}: Original: {originalValue}, Current: {currentValue}");
    }
