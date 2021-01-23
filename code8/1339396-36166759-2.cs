    var settings = new JsonSerializerSettings { ContractResolver = new DepthPruningContractResolver(depth), Formatting = Formatting.Indented };
    using (DepthPruningContractResolver.CreateTracker())
    {
        var jsonB = JsonConvert.SerializeObject(foob, settings);
        Console.WriteLine(jsonB);
        var jsonA = JsonConvert.SerializeObject(foob.FooA, settings);
        Console.WriteLine(jsonA);
    }
