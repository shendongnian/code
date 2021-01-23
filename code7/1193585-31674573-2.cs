    JObject o = new JObject
    {
        { "Cpu", "Intel" },
        { "Memory", 32 },
        {
            "Drives", new JArray
            {
                "DVD",
                "SSD"
            }
        }
    };
    JsonReader reader = o.CreateReader();
    while (reader.Read())
    {
        Console.Write(reader.TokenType);
        if (reader.Value != null)
            Console.Write(" - " + reader.Value);
        Console.WriteLine();
    }
