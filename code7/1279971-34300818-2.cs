    static async Task<object> GetAsync()
    {
        try
        {
            throw new Exception();
        }
        catch (Exception e)
        {
            return Task.FromException<Program>(e);
        }
    }
