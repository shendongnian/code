    var query=DbContext
      .Users
      .Where(r => r.FirstName.Contains(model.Search.Value) ||
                  r.LastName.Contains(model.Search.Value) ||
                  r.Email.Contains(model.Search.Value));
    
    switch(Model.Order)
    {
      case 1:
        query=(Model.Dir=="asc")?
          query.OrderBy(q=>q.id):
          query.OrderByDescending(q=>q.id);
        break;
      case 2:
        query=(Model.Dir=="asc")?
          query.OrderBy(q=>q.Name):
          query.OrderByDescending(q=>q.Name);
        break;
    }
    query=query
      .Skip(Model.Start)
      .Take(Model.Length);
