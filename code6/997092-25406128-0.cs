    public void InsertOrUpdate(Territory territory) 
    { 
        using (var context = new TravelEntities()) 
        { 
            context.Entry(territory).State = 
                          string.IsNullOrWhiteSpace(territory.TerritoryID) ? 
                                       EntityState.Added : 
                                       EntityState.Modified; 
            if (territory.Region!=null)
            {
                 context.Entry(territory.Region).State = 
                          territory.Region.RegionID == 0 ? 
                                       EntityState.Added : 
                                       EntityState.Modified;
            }
    
    
            context.SaveChanges(); 
        } 
    }
