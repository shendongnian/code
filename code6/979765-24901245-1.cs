    Registry registry = JsonConvert.DeserializeObject<Registry>(json);
    foreach (KeyValuePair<string, Device> pair in registry.Devices)
    {
        Console.WriteLine("MAC = {0}, ID = {1}", pair.Key, pair.Value.Id);
    }
