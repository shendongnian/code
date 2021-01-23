    FileHelperEngine engine = new FileHelperEngine(typeof(Account));
    engine.AfterReadRecord += engine_AfterReadRecord;
    try
    {
        Account[] importNodes = (Account[])engine.ReadFile(fname);  // XX
    }
    catch (Exception e)
    {
        
    }
    static void engine_AfterReadRecord(EngineBase engine, FileHelpers.Events.AfterReadEventArgs<object> e)
    {
        if (!string.IsNullOrEmpty(((Account) e.Record).Dummy))
        {
            throw new ApplicationException("Unexpected field");
        }
    }
