    List<Parent> parent = new List<Parent>();
    var parentIds = parent.
       Select(p => p
           // take C2 ids and C3 ids foreach Parent
          .C2.SelectMany(c2 => { return new List<string> { c2.Id, c2.C3.Id}; })
           // Add each C1 id foreach parent
          .Union(p.C1.Select(c1 => c1.Id))
           // Add its own id
          .Concat(new List<string> { p.id })
       );
