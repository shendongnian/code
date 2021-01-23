    var resultObjectList = _context.
                       Parents.
                       Where(p => p.DeletedDate == null).
                       OrderBy(p => p.Name).
                       Select(p => new
                                 {
                                     ParentItem = p,
                                     ChildItems = p.Children.Where(c => c.Name=="SampleName")
                                 }).ToList();
    
