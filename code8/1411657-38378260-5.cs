    public T MyMethod<T>(Func<T> action, Type exceptionType)
    {
        ...
        catch(Exception ex)
        {
            if(ex.GetType() == exceptionType)
