    public Task<string> GetAnswerAsync(string question)
    {
        try
        {
            return Task.FromResult(Lookup[question]);
        }
        catch(Exception e)
        {
            return Task.FromException<string>(e);
        }
    }
