    using (DbContext db = new DbContext(connectionString))
    {
        var send = new User { Name = "Sender" };
        db.Set<User>().Add(send);
        var rec = new User { Name = "Recipient" };
        var messages = new[] { new Message { Text = "a" }, new Message { Text = "b" } };
        var conv = new Conversation { SenderUser = send, RecipientUser = rec, Messages = messages };
        db.Set<User>().Add(rec);
        db.Set<Conversation>().Add(conv);
        db.SaveChanges();
    }
