    foreach(var user in convo.Members)
    {
         db.Entry(user).State = System.Data.Entity.EntityState.Unchanged;
    }
    db.Conversations.Add(convo);
