    var entities = new List<User>();
    entities.Add(new User { Name = "First", Type = "TypeA" });
    entities.Add(new User { Name = "Second", Type = "TypeB" });
    string[] columns = { "Name", "Type" };
    var selectResult = new List<string>();
    foreach (var columnID in columns)
    {
        selectResult.AddRange(entities.Select(e => e.GetType().GetProperty(columnID).GetValue(e, null).ToString()));
    }
    foreach (var result in selectResult)
    {
        Console.WriteLine(result);
    }
