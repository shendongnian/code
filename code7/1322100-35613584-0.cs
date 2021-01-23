    private static void OnMyObjectChanged(
        DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var obj = d as MyObject;
        if (obj != null)
        {
            ...
        }
    }
