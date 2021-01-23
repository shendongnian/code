    // optional query parameters coming from somewhere...
    DateTime? date;
    int? age;
    string username;
    
    IQueryable<T_USER> query = db.T_USER.AsQueryable();
 
    if(date != null)
        query = query.Where(u => u.JoinDate == date);
    if(age != null)
        query = query.Where(u => u.Age == age);
    if(username != null)
        query = query.Where(u => u.Username == username);
    var results = query.ToList();
