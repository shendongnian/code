    enum MessageStatus
    {
        Failure,
        Success
    }
    
    public async Task ChangeMessageStatus(string id)
    {
        string error = string.Empty;
        var status = MessageStatus.Failure;
        try
        {
            using (var db = new VinaChanelDbContext())
            {
                var message = db.Messages.SingleOrDefault(m => m.Id == id);
                if (message != null)
                {
                   message.IsRead = true;
                   if (await db.SaveChangesAsync() > 0)
                   {
                     status = MessageStatus.Success;
                   }
                }
            }
        }
        catch (Exception e)
        {
            error = e.Message;
        }
        switch (status)
        {
            case MessageStatus.Success:
                Clients.Caller.updateStatus(true);
                break;
            case MessageStatus.Failure:
                Clients.Caller.errorMessage(error);
                Clients.Caller.updateStatus(false);
                break;
        }
    }
