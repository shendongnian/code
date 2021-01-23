    try{
        db.Table_Name.Add(discussion);
        db.SaveChanges();
    }
    catch(Exception Ex){
        //trace the exception
    }
