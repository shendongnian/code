    public Task<List<string>> GetMessagesAsync()    
    {
        return _referralMessageData.GetMessagesAsync();
    }
    
    public Task<List<string>> GetMessagesAsync()
    {           
        return _context.Messages.Select(i => i.Message).ToListAsync();
    }
