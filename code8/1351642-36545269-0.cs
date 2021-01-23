    switch (UIViewSettings.GetForCurrentView().UserInteractionMode)
    {
        case UserInteractionMode.Mouse:
            listView.AllowDrop = true;
            listView.CanDragItems = true;
            listView.CanReorderItems = true;
            break;
    
        case UserInteractionMode.Touch:
        default:
            listView.AllowDrop = false;
            listView.CanDragItems = false;
            listView.CanReorderItems = false;
            break;
    }
