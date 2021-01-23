    using (var context = new EFDbContext())
    {
        using (var dbContextTransaction = context.Database.BeginTransaction())
        {
            try
            {
    			message.MessageThread = messageThread;
    
                // Message
                context.Messages.Add(message);
                context.SaveChanges();
    
                // Recipient
                context.Recipients.Add(recipient);
                context.SaveChanges();
    
                dbContextTransaction.Commit();
            }   
            catch //(Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong. Please try again.");
    
                return View("Message", model);
    
                // dbContextTransaction.Rollback(); no need to call this manually.
            }
        }   
    }
