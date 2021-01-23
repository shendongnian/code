    public void GenerateReport()
    {
        var didwork = false;
        try
        {
            ...
        }
        catch (Exception e)
        {
            this.log.LogError(...);
            throw; // Important!
        }
        finally
        {
            if (!didwork)
            {
                ...
            }
        }
    }
