    var container = (JContainer)Newtonsoft.Json.JsonConvert.DeserializeObject(response);
    var message = container["message"];
    if(message == null)
    {
        var obj = container.ToObject<List<Trace>>();
        //Do whatever you need to do with the object
    }
    else
    {
        var msg = container.ToObject<RootObject>();
        //Do whatever you need to do with the object
    }
