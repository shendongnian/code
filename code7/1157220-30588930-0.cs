      UserInfo results = new UserInfo
        {
            Name = Request["name"],
        };
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        JsonWriter jsonWriter = new JsonTextWriter(sw);
        jsonWriter.Formatting = Formatting.Indented;
        jsonWriter.WriteStartObject();
        jsonWriter.WritePropertyName("Name");
        jsonWriter.WriteValue(results.Name);
        jsonWriter.WriteEndObject();
        string json = sw.ToString();
        jsonWriter.Close();
        sw.Close();
        
        string path = @"C:\inetpub\wwwroot\JSON\json.Net\results.json";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, json);
        }
        else
        {
            File.AppendAllText(path, json);
        }
    }
    // create a class object to hold the JSON value
    public class UserInfo
    {
        public string Name { get; set; }
    }
