    public static void PrintLeafNames(IEnumerable<JToken> tokens)
    {
        foreach (var token in tokens)
        {
            if (token.Type == JTokenType.Property)
            {
                JProperty prop = (JProperty)token;
                if (!prop.Value.HasValues)
                    Console.WriteLine(prop.Name);
            }
            if (token.HasValues)
                PrintLeafNames(token.Children());
        }
    }
