    public static void SafeExecute(Func<Task> asyncActionThatMayThrowException)
    {
        try
        {
            await asyncActionThatMayThrowException();
        }
        catch
        {
            // noop
        }
    }
