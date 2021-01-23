    switch(UIViewSettings.GetForCurrentView().UserInteractionMode)
    {
      case UserInteractionMode.Mouse:
        // Tablet code
        break;
 
      case UserInteractionMode.Touch:
      default:
        // Laptop code
        break;
    }
