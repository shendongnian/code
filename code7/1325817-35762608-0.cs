    JsonSerializerSettings settings = new JsonSerializerSettings();
    settings.Converters.Add(new ListCompactionConverter());
    settings.Formatting = Formatting.Indented;
    var result = JsonConvert.SerializeObject(customers,settings); 
    return(result);
