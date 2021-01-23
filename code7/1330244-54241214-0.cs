    // disconnected entity to be deleted
    var student = new Student(){ StudentId = 1 };
    using (var context = new SchoolDBEntities())
    {
        context.Entry(student).State = System.Data.Entity.EntityState.Deleted;    
        context.SaveChanges();
    }  
