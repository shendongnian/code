    var jsonStr = "{\"ver\":\"1\",\"item1\":{\"name\":\"name1\",\"desc\":\"desc1\"},\"item2\":{\"name\":\"name2\",\"desc\":\"desc2\"},\"item3\":{\"name\":\"name3\",\"desc\":\"desc3\"}}";
    
    List<string> names = new List<string>();
    JObject jsonObject = JObject.Parse(jsonStr);
    jsonObject.Remove("ver");
    foreach (JToken jsonRow in jsonObject.Children())
    {
        foreach (JToken item in jsonRow)
        {
            foreach (JToken itemProperty in item)
            {
                var property = itemProperty as JProperty;
                if (property != null && property.Name == "name")
                {
                    if (property.Value != null)
                    {
                        names.Add(property.Value.ToString());
                    }
                }
            }
        }
    }
