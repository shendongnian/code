    using (var context = new EFDbContext())
    {
        using (var dbContextTransaction = context.Database.BeginTransaction())
        {
            try
            {
                // MessageThread
                MessageThread messageThread = new MessageThread();
                context.MessageThreads.Add(messageThread);
                context.SaveChanges();
                // Message
                Message message = new Message
                {
                    Subject = model.Subject,
                    MessageText = model.MessageText,
                    DateSent = DateTime.UtcNow,
                    SenderID = sender.Id,
                    MessageThreadID = messageThread.MessageThreadID
                };
                context.Messages.Add(message);
                context.SaveChanges();
                etc.
