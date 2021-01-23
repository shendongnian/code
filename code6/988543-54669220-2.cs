    var person = new Person();
    var jsonResolver = new PropertyRenameAndIgnoreSerializerContractResolver();
    
    jsonResolver.IgnoreProperty(typeof(Person), "Title");
    jsonResolver.RenameProperty(typeof(Person), "FirstName", "firstName");
    var serializerSettings = new JsonSerializerSettings();
    serializerSettings.ContractResolver = jsonResolver;
           
    var json = JsonConvert.SerializeObject(person, serializerSettings);
 
