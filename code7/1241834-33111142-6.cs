    try
    {
        // Database operations starts 
        // perform database operations
        transaction.Commit();
    }
    catch (DataException ex)
    {
        // rollback
        transaction.RollBack();
        // I'm keeping the original error but lying about the stack stace
        throw new InvalidOperationException(name, ex);
    }
