    private void CheckExecuteAndHandleErrors(Action action)
    {
        // preconditions
        // logging
        try
        {
            action();
        }
        catch (SomeException e)
        {
            // handle errors
        }
    }
