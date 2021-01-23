    public void Execute(object parameter)
    {
        var button = (Button)parameter;
        var splitView = FindParent<SplitView>(button);
        splitView.IsPaneOpen = !splitView.IsPaneOpen;
    }
