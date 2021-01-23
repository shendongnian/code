    public static void Call<T>(Action<T> action)
        where T: ICommunicationObject, new()
    {
        T serviceProxy = new T();
        try
        {
            action(serviceProxy);
            serviceProxy.Close();
        }
        catch (Exception ex)
        {
            serviceProxy.Abort();
            throw;
        }
    }
