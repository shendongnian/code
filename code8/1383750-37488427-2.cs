    private static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ActionBar actionBar = d as ActionBar;
        // Do other stuff
        switch ((NavigationStyle)e.NewValue)
        {
            case NavigationStyle.SingleNavigation:
                // here i need to edit the width of the ActionBar to 500px
                break;
            case NavigationStyle.TwoColumnsNavigation:
                // and here i have to edit the ActionBar width to 700
                break;
            default:
                break;
        }
    }
