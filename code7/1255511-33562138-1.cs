    public void DeleteItem(Equipment obj)
    {
        var db = new AppContext();
        db.Equipment.Remove(obj);
        db.SaveChanges();
    }
    public void DeleteItemById(int equipmentId)
    {
        var equipment = new Equipment 
        { 
            EquipmentId = equipmentId
        };
        // this should really be done in the constructor, as you want to keep the context for the lifetime of your repository, which should encompass a unit of work 
        var db = new AppContext(); 
        db.Equipment.Attach(equipment);
        db.Equipment.Remove(equipment);
        db.SaveChanges();
    }
