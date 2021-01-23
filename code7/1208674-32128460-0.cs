    var test = new int[]; // assume it's filled
    var result = db.Table<Message>().Where(cond => test.Contains(cond.ID));
    foreach(var message in result)
        message.Status = status;
    db.SaveChanges(); //or something similar.
 
