    dynamic array = JsonConvert.DeserializeObject(File.ReadAllText(pathToMyJsonFile));
    foreach (var item in array)
    {
        Console.WriteLine(item.name + " " + item.traits.Hair);
    }
