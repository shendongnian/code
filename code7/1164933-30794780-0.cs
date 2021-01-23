    var query = db.person;
    if(!String.IsNullOrEmpty(name))
        query = query.Where(a => a.person.contains(name));
    var result = query.Select(s => new { Name = s.FullName, DOB = s.DOB })
                      .toList();
