    public async Task<List<string>> GetMessagesAsync()    
    {
        return await _referralMessageData.GetMessagesAsync().ConfigureAwait(false);
    }
    
    public async Task<List<string>> GetMessagesAsync()
    {           
        return await _context.Messages.Select(i => i.Message).ToListAsync().ConfigureAwait(false);
    }
