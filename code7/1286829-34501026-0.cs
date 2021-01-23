       var settings = new JsonSerializerSettings()
       {
          TypeNameHandling = TypeNameHandling.Objects
       };
       string json = JsonConvert.SerializeObject(templateA, settings);
    
       TemplateA templateACopy = 
                JsonConvert.DeserializeObject<TemplateA>(jsonString, settings);
