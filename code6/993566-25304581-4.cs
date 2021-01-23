    public static async Task SafeExecute(Func<Task> asyncActionThatMayThrowException)
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
