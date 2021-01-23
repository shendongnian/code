    public delegate void MyDelegate(); // Delegate declaration - it basically a function signature, nothing else.
    public void ComposeDelegates()
    {
        MyDelegate c = Destroy; // Creates a delegate
        c += ShowPoints; // add ShowPoints to invocation list
        c -= ShowPoints; // Remove ShowPoints from invocation list
        c.Invoke(); // Calls delegate, i.e. invokes all methods attached to delegate.
    }
    public void Destroy()
    {
    }
    public void ShowPoints()
    {
    }
