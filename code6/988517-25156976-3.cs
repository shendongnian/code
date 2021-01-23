    public void GiveMeAProperName(Action<DBContext> databaseAction)
    {
        GiveMeAProperName(context =>
        {
            databaseAction(context);
            return "ignored";
        }
    }
