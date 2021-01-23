    // using System.Reflection;
    foreach (var property in dbEntry.Entity.GetType().GetTypeInfo().DeclaredProperties)
    {
        var originalValue = entry.Property(property.Name).OriginalValue;
        var currentValue = entry.Property(property.Name).CurrentValue;
        Console.WriteLine($"{property.Name}: Original: {originalValue}, Current: {currentValue}");
    }
