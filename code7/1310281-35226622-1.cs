    IEnumerable<EntityTypeYouveDefined> listOfEntities;
       
    using (var _data = new My.EF.MyEntities())
    {
        listOfEntities = _data.YourTableName.Where(e => e.SomeConditionOrPropertyOrWhatever);
        //Or some other search predicate to pull what you want to change.
    }
    foreach(var entity in listOfEntities)
    {
        entity.SomeProperty = "what you want to change";
    }
    using (var _data = new My.EF.MyEntities())
    {
        foreach(var entity in listOfEntities)
        {
            _data.Entry(entity).State = EntityState.Modified;
        }
        _data.SaveChanges();
    }
