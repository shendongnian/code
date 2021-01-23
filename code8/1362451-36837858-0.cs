    using(_context = new dbContext()){    //This will dispose the context           
    string userName = //getting this value from somewhere else;
    string userRoleNo = //getting this value from somewhere else;
    Student student = _context.Students.FirstOrDefault(x => x.UserId == new Guid(userId));
    
    
    if (student != null)
     {
       student.userName = userName; 
       student.userRoleNo = userRoleNo; 
       student.Date = DateTime.Now ;
       _context.Entry(student).State = EntityState.Modified;     
     }          
     else
     {
          student = new Student () {
           userName = userName, 
           userRoleNo = userRoleNo, 
           Date = DateTime.Now 
        };
      _context.Students.Add(student);
    }
    _context.SaveChanges();
    }; 
