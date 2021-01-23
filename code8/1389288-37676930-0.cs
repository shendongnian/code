    using Newtonsoft.Json;
    
    var person = new  
    {
    	Name  = _Name,
    	FirstName  = _FirstName,
    	BirthDate  = _BirthDate,
    	Photo = _Photo 
    };
    
    var rootUrl = "yoururl";
    var dataString = JsonConvert.SerializeObject(person);
    
    using (var client = new WebClient())
    {
        client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
    	response = client.UploadString(new Uri(rootUrl), "POST", dataString);
    }
