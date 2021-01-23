    public void Go()
    {
        Debug.WriteLine("BreakPoint 1");
        try
        {
            _storyboard.Begin();
        }
        catch (Exception)
        {
            Debug.WriteLine("BreakPoint 2");
            System.Diagnostics.Debugger.Break();
        }
    }
