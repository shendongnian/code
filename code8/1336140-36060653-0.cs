    Dictionary<string, object> dictionary = new Dictionary<string, object>();
    while (csv.Read())
    {
      string path = csv.GetField<string>(0);
      string value = csv.GetField<string>(1);
      dictionary = GetHierarchy(path, value);
    }
    string serialized = JsonConvert.SerializeObject(dictionary);
    Console.WriteLine(serialized);
