    var messageId = sendMessage();
    using (var db = new DBModel())
    {
        var message = new Message()
        {
            MessageId = messageId,
            Sent = 0,
            // Other properties
        };
    
        db.Messages.Add(message);
        db.SaveChanges();
        bool sent = false;
        while (!sent)
        {
            db.Detach(message); // <<< This part
            message = db.Messages.FirstOrDefault(m => m.MessageId == messageId);
            var i = message.Sent;
            if (i == -1) throw new Exception();
            sent = i == 1;
        }
    }
