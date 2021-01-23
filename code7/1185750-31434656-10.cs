    private void CheckExecuteAndHandleErrors(Action action)
    {
        // preconditions
        try
        {
            action();
        }
        catch (SomeException e)
        {
            // handle errors
        }
    }
