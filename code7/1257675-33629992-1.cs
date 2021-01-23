    using (DataEntities context = new DataEntities())
    {
        foreach (int ID in IDList)
        {
            TableName item = new TableName();
            item.ID = ID;
            context.TableName.Attach(item);
            item.IsDeleted = true; //Change a filed's value
        }
        context.SaveChanges();
    }
