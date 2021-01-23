    public T GetById( String id )
    {
        return GetById<T>( id );
    }
    public U GetById<U>( String id ) where U : T
    {
        return this.Context.Set<U>().Find( id );
    }
