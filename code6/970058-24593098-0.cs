    Class Person 
    {
    public int id {get;set;} 
    public string name {get;set;} 
    }
    
    var person = JsonConvert.DeserializeObject<Person>(jsonString);
   
    if you dont want to create class use JObject 
    dynamic newObj = JObject.Parse(jsonString);
    string id= newObj.id ;
    string name= newObj.name;
