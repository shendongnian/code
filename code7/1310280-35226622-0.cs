    var listOfEntities = new List<EntityTypeYouveDefined>();
    for (int i = 0; i < 17348; i++)
    {
        var newEntity = new EntityTypeYouveDefined();
        //Build the newEntity relationships here
        listOfEntities.Add(newEntity);
    }
    
    using (var _data = new My.EF.MyEntities())
    {
        foreach (var entity in listOfEntities)
        {
            _data.Attach(newEntity)
            //You may have to set the entity state to modified here. Can't remember, I'm doing this from memory
        }
        _data.SaveChanges();
    
    }
