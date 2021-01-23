    public void GiveMeAProperName(Action<DBContext> databaseAction)
    {
        GiveMeAProperName(() =>
        {
            databaseAction();
            return "ignored";
        }
    }
