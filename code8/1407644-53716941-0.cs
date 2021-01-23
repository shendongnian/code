    public Foo Selected
    {
        get
        {
            if (!Environment.StackTrace.Contains("CanExecute"))
                System.Diagnostics.Debugger.Break();
            return _selected;
        }
    }
