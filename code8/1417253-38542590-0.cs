    var query = db.Student.AsQueryable();
    if (age != null)
        query = query.Where(s => s.Age == age.Value);
    if (fname != null)
        query = query.Where(s => s.Firstname == fname.Value);
    // etc...
    var student = query.FirstOrDefault();
