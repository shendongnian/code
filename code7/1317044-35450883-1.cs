    List<string> categories = new List<string>();
    StreamReader reader = new StreamReader("data.json"); // assuming you are reading from a file
    string jsonString = reader.ReadToEnd();
    JArray data = JArray.Parse(jsonString);
    foreach (JObject entry in data.Children<JObject>())
    {
      foreach (JProperty p in entry.Properties())
      {
        if (p.Name.Equals("sub_category_en"))
        {
          string value = (string)p.Value;
          categories.Add(value);
        }
      }
    }
