    var members = GetCollectionOfMember();
    
    foreach(var member in members)
    {
        foreach(var serviceString in member.Services)
        {
            Services service;
            if(Enum.TryParse<Services>(serviceString, out service))
            {
                 var serviceName = service.ToString();
            }
        }
    }
