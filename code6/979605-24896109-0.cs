     TODO theEntity = db.TODOs.Where(r=>r.ID == id).SingleOrDefault();//This will throw an exception if there are duplicate ids
     if (theEntity  == null)
     {
          theEntity = new TODO();
          db.TODOs.Add(theEntity);
     }
    
     //Updates Fields Here
     db.SaveChanges();
