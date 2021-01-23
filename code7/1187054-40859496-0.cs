    try
    {
        if(db.Students.Any(s=>s.ID == id)
        {
          Student stu = new Student() { ID = id };
          db.Entry(stu).State = EntityState.Deleted;
          int result = db.SaveChanges();
        }
    
        
    }
    catch (DataException e)
    {
    
    }
