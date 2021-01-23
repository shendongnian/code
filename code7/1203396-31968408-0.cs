    var query = session.QueryOver<Client>()
        .Where(x => x.IsDeleted == false);
    if (status == "active")
       query = query.Where(x => x.IsActive == true);
    var clients = query.List(); // To execute the query and get the result (root entity)
