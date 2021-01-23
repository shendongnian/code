    public IQueryable<ChatMessage> GetChatMessage(int pageSize, int ownerUserId, int friendUserId, DateTime oldestMessageDate)
    {
       var query = this.GetQueryable().
                  Where(x => ((x.Sender.Identifier == ownerUserId && x.Receiver.Identifier == friendUserId) 
                         || (x.Sender.Identifier == friendUserId && x.Receiver.Identifier == ownerUserId)) 
                         && x.MessageTime < oldestMessageDate); 
        //query now has all the messages older than messages shown to the user
        
        query = query.OrderByDescending(x => x.Identifier).Take(PageSize);
        return query;
    }
