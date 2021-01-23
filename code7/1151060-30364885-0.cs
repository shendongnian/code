    // convert string/file to YAML object
    var r = new StreamReader(filename); 
    var deserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());
    var yamlObject = deserializer.Deserialize(r);
    
    // now convert the object to JSON. Simple!
    Newtonsoft.Json.JsonSerializer js = new Newtonsoft.Json.JsonSerializer();
    
    var w = new StringWriter();
    js.Serialize(w, o);
    string jsonText = w.ToString();
