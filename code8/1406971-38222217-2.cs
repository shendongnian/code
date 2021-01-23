    private void SwapView(IView newView)
    {
        // Get current view
        IView currentView = ...
        // Check whether it can be closed
        if (!currentView.CanClose())
        {
            ...
            return;
        }
        // Remove old user control
        ...
        // Show new user control
        ...
    }
