    public bool InsertChilds(List<Child> childs, Parent childParent)
    {
        // This will save more time . 
        DataContext).Configuration.AutoDetectChangesEnabled = false;
        foreach(var child in childs)
        {
            //This will set the child parent relation
            child.Parent = childParent;
            db.ChildEntity.Insert(child);
        }
        DataContext).Configuration.AutoDetectChangesEnabled = true;
        db.SaveChanges();
    }
