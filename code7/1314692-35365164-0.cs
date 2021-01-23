    private static readonly object o = new Object();
    public SomeModel Get(int id)
        lock (o)
        {
            ...
            credit.Availbale -= 1;
            dbContext.SaveChanges();
        }
