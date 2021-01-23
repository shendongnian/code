    Sample sample= new Sample();
     var     properties=sample.GetType().GetProperties().Where(x=>x.Name!="ResponseType");
     var response = new Dictionary<string,object>() ;
    foreach(var prop in properties)
     {
        var propname = prop.Name;
       response[propname] = prop.GetValue(sample); ;
    }
     var response= Newtonsoft.Json.JsonConvert.SerializeObject(response);
