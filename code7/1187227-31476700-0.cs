     dynamic jsonFile = JObject.Parse(Utilities.ReadFile("~/Content/images/Gallery/Gallery.json"));
            
    using (FileStream fs = File.Open(@"~/Content/images/Gallery/Gallery.json", FileMode.Open)) //may have to server.mappath this
    using (StreamWriter sw = new StreamWriter(fs))
    using (JsonWriter jw = new JsonTextWriter(sw))
    {
        jw.Formatting = Formatting.Indented;
            
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(jw, jsonFile);
    }
