    private static DependencyProperty ItemsProperty = DependencyProperty.Register("Items",
        typeof(ObservableCollection<SubChildClass>), typeof(CustomControl1));
    public ObservableCollection<SubChildClass> Items
    {
        get { return (ObservableCollection<SubChildClass>)GetValue(ItemsProperty); }
        set { SetValue(ItemsProperty, value); }
    }
