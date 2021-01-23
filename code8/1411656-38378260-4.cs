    public T MyMethod<T>(Func<T> action, Exception example)
    {
        ...
        catch(Exception ex)
        {
            if(ex.GetType() == example.GetType())
