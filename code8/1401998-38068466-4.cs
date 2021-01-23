    public Wrapper<TResult> To<TResult>() where TResult : class// TResult must also be (derived from) Base
    {
        if (!typeof(TResult).IsAssignableFrom(typeof(T)))
            throw new InvalidCastException();
        return new Wrapper<TResult>(Value as TResult);
    }
