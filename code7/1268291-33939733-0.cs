    public void Add(Message message)
    {          
        using (var ctx = new ShowcaseContext())
        {
            foreach (var reci in message.Recipients)
            {
                ctx.Users.Attach(reci.User);
            }
            ctx.Messages.Add(message);
            ctx.Entry(message.Sender).State = EntityState.Detached;
            ctx.SaveChanges();
        }
    }
