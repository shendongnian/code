    Console.WriteLine(wordDefinition.Word);
    Console.WriteLine();
    foreach (var definition in wordDefinition.Definitions)
    {
        Console.WriteLine("Word: " + definition.Word);
        Console.WriteLine("Word Definition: " + definition.WordDefinition);
        Console.WriteLine("Id: " + definition.Dictionary.Id);
        Console.WriteLine("Name: " + definition.Dictionary.Name);
    }
