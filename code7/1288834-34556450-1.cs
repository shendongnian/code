    public IQueryable<ChatMessage> GetChatMessage(int PageNo, int PageSize, int ownerUserId, int friendUserId, DateTime oldestMessageDate)
    {
        var query = this.GetQueryable().
                  Where(x => ((x.Sender.Identifier == ownerUserId && x.Receiver.Identifier == friendUserId) ||
                    (x.Sender.Identifier == friendUserId && x.Receiver.Identifier == ownerUserId)) && x.MessageTime < oldestMessageDate);
        query = query.OrderByDescending(x => x.Identifier).Take(PageSize);
        return query;
    }
