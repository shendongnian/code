    if (item.TypeNames.FirstOrDefault() == "System.String")
    {
        return item.BaseObject.ToString();
    }
    else
    {
        var settings = new Newtonsoft.Json.JsonSerializerSettings
            { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
        var dict = new Dictionary<string, object>();
        var objMembers = typeof(object).GetMembers();
        var ignoreMembers = new List<string>();
        ignoreMembers.AddRange(
            item.Members.Where(
                i => i.TypeNameOfValue.StartsWith("Deserialized.")).Select(i => i.Name).ToList());
        ignoreMembers.AddRange(objMembers.Select(i => i.Name));
        var filteredMembers =
            item.Members.Where(
                i => ignoreMembers.All(
                    ig => ig.ToLower() != i.Name.ToLower())).ToList();
        foreach (var mem in filteredMembers)
        {
            if (!dict.ContainsKey(mem.Name))
            {
                dict.Add(mem.Name, "");
            }
            dict[mem.Name] = mem.Value;
        }
        try
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(dict, settings);
        }
        catch (Exception e)
        {
        }
    }
    return null;
