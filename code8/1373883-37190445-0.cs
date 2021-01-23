    List<Parent> parent = new List<Parent>();
    var parentIds = parent.
       Select(p => p
          .C2.SelectMany(c2 => { return new List<string> { c2.Id, c2.C3.Id}; })
          .Union(p.C1.Select(c1 => c1.Id))
          .Concat(new List<string> { p.id })
       );
