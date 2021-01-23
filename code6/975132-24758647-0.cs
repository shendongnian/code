    ResponseArray.OrderBy(t => t.ParentID).Select(t => new TestParent()
        { 
            ParentID = t.ParentID,
            GroupItems = t.GroupItems.OrderBy(g => g.GroupID).ToList() 
        })
