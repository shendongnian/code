    JsonObjectContract contract = (JsonObjectContract)resolver.ResolveContract(typeof(DTO));
    var dict = contract.Properties.ToDictionary(p => p.UnderlyingName, p => p.PropertyName);
    Console.WriteLine("Serialized property names will be: ");
    foreach (var kvp in dict)
    {
        Console.WriteLine(kvp.Key + " => " + kvp.Value);
    }
