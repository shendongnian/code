    list.Select(o =>
    { 
       var parent = new ParentClass
        {
            ID = o.ID
        };
        parent.ChildClass = o.Childs
                            .Select(p =>
                               new ChildClass 
                               { 
                                   Parent = parent,
                                   ID = p.id 
                               })
                             .ToList();
         return parent;
    });
