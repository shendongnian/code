    var parentDictionary = AsEnumerable().ToDictionary(p => p.Id);
    Ienumerable<Parent> children = II.asEnumerable()
        .Where( c => parentDictionary.Keys.Contains(c.ParentId))
        .Select(c => new Child()
            {
                A = parentDictionary[c.Id].A,
                B = parentDictionary[c.Id].B,
                C = c.C,
                D = c.D
             })
        .Cast<Parent>();
    
    IEnumerable<Parent> parentsWithoutChildren = I.AsEnumerable()
        .Where(p => !II.AsEnumerable().Contains(p.Id));
    
    IEnumerable<Parent> requestedPersons = parentsWithoutChildren
        .Concat(children);
