    var usr = context.USERS.Select(u => u);    
    if (!string.IsNullOrWhiteSpace(name))
        usr = usr.Where(u => u.NAME == name);    
    if (!string.IsNullOrWhiteSpace(password))
        usr = usr.Where(u => u.PASSWORD == password);
    return usr.ToList();
