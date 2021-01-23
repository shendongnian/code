    // Test if the .NET framework dispatches the method if you apply the following attribute
    //[ComVisible(false)]
    [DispId(-4)]
    public IEnumerator NewEnum()
    {
        return ((IEnumerable)this).GetEnumerator();
    }
