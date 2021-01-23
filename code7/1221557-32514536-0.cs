    DBModel db;
    var messageId = sendMessage();
    using (db = new DBModel())
    {
        db.Messages.Add(new Message()
        {
            MessageId = messageId,
            Sent = 0,
            // Other properties
        });
        db.SaveChanges();
    } 
    bool sent = false;
    while (!sent)
    {
    	using (db = new DBModel())
    	{
            int i = db.Messages.FirstOrDefault(m => m.MessageId == messageId).Sent;
            if (i == -1) throw new Exception();
            sent = i == 1;
        }
    }
