    using (var db = new MyDbContext())
    {
      string fromUser = ""; //sender
      string toUser = ""; //receiver
      var messages = db.Message.Where(x => x.FromUser == fromUser && x.ToUser == toUser)
                     .ToList();
      messages.ForEach(m => m.IsRead = true);
      db.SaveChanges();
    }
