    try 
    {
        Monitor.Enter(GameBoard.syncObject);
        // Target Code
    }
    finally 
    {
        Monitor.Exit(GameBoard.syncObject);
    }
