    [Query(HasSideEffects = true)]    //<--- this line solved the problem
    public IQueryable<EventView> GetEventView(List<string> siteName)
    {
     .....
    }
