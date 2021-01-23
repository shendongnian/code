    public static readonly DependencyProperty ItemHeightProperty = 
      DependencyProperty.Register(
        "ItemHeight", 
        typeof (GridLength), 
        typeof (TreeViewItem), 
        new FrameworkPropertyMetadata(new GridLength(30)));
    /// <summary>
    /// Indique si un overlay est présent
    /// </summary>
    public GridLength ItemHeight
    {
        get
        {
            return (GridLength)GetValue(ItemHeightProperty);
        }
        set
        {
            SetValue(ItemHeightProperty, value);
        }
    }
