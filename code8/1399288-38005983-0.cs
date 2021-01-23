    JArray array = JArray.Parse(jsonString);
    List<object> parts = new List<object>();
    JArray array = JArray.Parse(jsonString);
    parts.Add(array[0].ToObject<int>());
    parts.Add(array[1].ToObject<DateTime>());
    ....
    string formattedString = string.Join("|", parts);
