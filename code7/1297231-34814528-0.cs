    // 'this' is your UI element
    bool inDesign = DesignerProperties.GetIsInDesignMode(this);
    if (!inDesign)
    {
        if ((bool)value == true)
        {
            return new BitmapImage(new Uri("pack://application:,,,/Resources/green_orb_24x24.png", UriKind.Absolute));
        }
        else
        {
            return new BitmapImage(new Uri("pack://application:,,,/Resources/red_orb_24x24.png", UriKind.Absolute));
        }
    }
    else
    {
         return null;
    }
