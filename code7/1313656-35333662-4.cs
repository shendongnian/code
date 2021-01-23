    if(ActiveId == 1)
    {
        data = data.Where(c => c.IsActive);    
    }
    else if(ActiveId == 1)
    {
        data = data.Where(c => c.IsActive);  
    }
    if (LocationId != 0)
    {
        data = data.Where(c => c.LocationId == LocationId);  
    }
 
    if (stats == "subscribe")
    {
        data = data.Where(c => c.IsActive 
          && c.SubscribeDate >= DateTime.Now.AddDays(-7));  
    }
    else if (stats == "unbsubscribe")
    {
        data = data.Where(c => !c.IsActive 
          && c.SubscribeDate >= DateTime.Now.AddDays(-7));  
    }
    
