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
        this.DeleteItem(equipment);
    }
