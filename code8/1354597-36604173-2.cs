       public async Task<List<Topic>> Get() {
            return await db.Topic
                      .Where(t => t.State == MessageState.Allowed)
                      .OrderByDescending(topic => topic.DatePosted)
                      .ToListAsync();
       }
