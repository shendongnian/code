    var dataContect = "DataContext";
    var frameworkElement = sender as FrameworkElement;
    if ( frameworkElement != null )
    {
        frameworkElement.DataContext = dataContect;
    }
    else
    {
        var frameworkContentElement = sender as FrameworkContentElement;
        if ( frameworkContentElement != null )
        {
            frameworkContentElement.DataContext = dataContect;
        }
    }
