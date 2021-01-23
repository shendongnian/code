    public void DoBackGroundWork()
    {
        ChronicusContext dbContext = new ChronicusContext();
        while (true)
        {
           if (dbContext.PollModels.Any())
           {
              ...
           }
        }
    }
