    private void Push(IFoo p)
    {
        if (p.CurrentToken != null)
        {
            p.CurrentToken.Cancel();
            p.CurrentToken.Dispose();
            p.CurrentToken = null;
        }
        _stack.Push(p);
    }
