    // If you required such a high isolation level, so be it, but try
    // avoiding it otherwise.
    var tran = session.BeginTransaction(IsolationLevel.Serializable);
    try
    {
        session.GetNamedQuery("yourInsertsQuery")
            .SetParameter("someParam", someValue)
            .SetParameter("someOtherParam", someOtherValue)
            .ExecuteUpdate();
        session.GetNamedQuery("yourDeleteQuery")
            .SetParameter("someParam", someValue)
            .SetParameter("someOtherParam", someOtherValue)
            .ExecuteUpdate();
        tran.Commit()
    }
    catch
    {
        try
        {
            tran.Rollback();
        }
        catch(Exception rollbackEx)
        {
            // better log rollbackEx then swallow it (no throw in this nested catch)
            // to let original trouble bubble up.
        }
        // Let original failure bubble up
        throw;
    }
