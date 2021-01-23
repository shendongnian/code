    #region OwnerDataContext Property
    public Object OwnerDataContext
    {
        get { return (Object)GetValue(OwnerDataContextProperty); }
        set { SetValue(OwnerDataContextProperty, value); }
    }
    public static readonly DependencyProperty OwnerDataContextProperty =
        DependencyProperty.Register("OwnerDataContext", typeof(Object), typeof(SubWindow),
            new PropertyMetadata(null));
    #endregion OwnerDataContext Property
