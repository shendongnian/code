    dbContext _context = new dbContext();     
    var student = _context.Students.FirstOrDefault(x => x.UserId == new Guid(userId)); // Get the existing student.
    bool exists = true;
    if(student == null){
        student = new Student();
        exists = false;
    }
        
    string userName = //getting this value from somewhere else;
    string userRoleNo = //getting this value from somewhere else;
    student.userName = userName; // Do you really want to reset this?
    student.userRoleNo = userRoleNo;
    student.Date = DateTime.Now:
    
    if(!exists){
        _context.Students.Add(student);
    }
    _context.SaveChanges(); 
