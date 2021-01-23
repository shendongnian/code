    public static Exception RunCodeThatMayThrowException(Action action)
    {
        try
        {
            action.Invoke();
            return null;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }
