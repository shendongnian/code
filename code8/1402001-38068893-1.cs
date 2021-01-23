    public Wrapper<TResult> To<TResult>() where TResult : T 
        => new Wrapper<TResult>( (TResult)Value ); // This could throw an error
    public bool TryCastTo<TResult>(out Wrapper<TResult> derivedWrapper) where TResult : T
    {
        derivedWrapper = null;
        // EDIT: changed to the version from René Vogt since this is much cleaner and mine had a little error
        if (!typeof(T).IsAssignableFrom(typeof(TResult)))
        {
            return false;
        }
        derivedWrapper = new Wrapper<TResult>( (TResult)Value );
        return true;
    }
