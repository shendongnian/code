    List<dynamic> test = NewMassType.GetAll().Where(e => e.ParentId == null);
    foreach (var element in test)
    {
        PopulateChildren(element);
    }
    // Somewhere down the line have a method
    public void PopulateChildren(dynamic element) 
    {
        var children = NewMassType.GetAll().Where(e => e.ParentId == element.Id);
        element.children = children;
        foreach (var child in element.children)
        {
             PopulateChildren(child);
        }        
    }
   
