    public void Execute<T>( T value) 
    {
        if( value is int )
        {
            IntDoSomething();
        }
        else if( value is float)
        {
            FloatDoSomething();
        }
    }
