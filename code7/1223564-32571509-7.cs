    using (var responseStreamReader = new StreamReader(webResponse.GetResponseStream()))
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ServiceResources));
        ServiceResources deserialized = (ServiceResources)serializer.Deserialize(responseStreamReader);
        
         //you can access each item in loop
        foreach(var res in deserialized.ServiceResource)
        {
           //access items e.g.
           var name = res.Name;
        }
    }
