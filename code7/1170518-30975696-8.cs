    public static readonly DependencyProperty DropBordersProperty = 
        DependencyProperty.RegisterAttached("DropBorders", typeof(BorderCollection), typeof(MyDragDrop),
        new PropertyMetadata(null, DropBordersChanged));
    public static BorderCollection GetDropBorders(DependencyObject listView)
    {
        return (BorderCollection)listView.GetValue(DropBordersProperty);
    }
    public static void SetDropBorders(DependencyObject listView, BorderCollection borders)
    {
        listView.SetValue(DropBordersProperty, borders);
    }
    public static void DropBordersChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        foreach (var border in (BorderCollection)e.NewValue)
            border.Background = new SolidColorBrush(Colors.Red);
    }
