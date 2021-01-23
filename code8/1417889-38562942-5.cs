    public void ExecuteIfWasNotCalledDuringLast( string name, int milliseconds, Action action )
    {
        if ( !WasCalledDuringLast( name, milliseconds ) )
        {
            RegisterCallOf( name );
            action();
        }
    }
