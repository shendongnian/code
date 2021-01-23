    var assembly = typeof(MyCustomAttribute).GetTypeInfo().Assembly;
    foreach (var type in assembly.GetTypes())
    {
      var attribute = type.GetTypeInfo().GetCustomAttribute<MyCustomAttribute>();
      if (attribute != null)
      {
          _definedPackets.Add(attribute.MarshallIdentifier, type);
      }
    }
