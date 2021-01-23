    var subject = new Subject 
    { 
        Name = "Physics" 
    };
    _db.Subjects.Add(subject);
    var student = new Student 
    { 
        Name = "venerik", 
        Subjects = new List<Subject> { subject }
    };
    _db.Students.Add(student);
    _db.SaveChanges();
   
