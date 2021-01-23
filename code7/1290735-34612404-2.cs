    public bool InsertParent(Parent parentObject)
    {   
        //Assuming this is the parent table
        db.BigObjects.Add(parentObject);
        InsertChilds(parentObject); //Insert childs
        db.SaveChanges();
    }
    public bool InsertChilds(Parent parentObject)
    {
        // This will save more time . 
        DataContext).Configuration.AutoDetectChangesEnabled = false;
        foreach(var child in parentObject.Childs)
        {
            //This will set the child parent relation
            child.Parent = childParent;
            db.ChildEntity.Add(child);
        }
        DataContext).Configuration.AutoDetectChangesEnabled = true;
       
    }
