    var messageIDs = new int[]; // assume it's filled
    var result = db.Table<Message>().Where(cond => messageIDs.Contains(cond.ID));
    foreach(var message in result)
        message.Status = status;
    db.SaveChanges(); //or something similar.
 
