    #region ViewModelObject 
    public YourViewModel ViewModelObject
    {
        get { return (YourViewModel)GetValue(ViewModelObjectProperty); }
        set { SetValue(ViewModelObjectProperty, value); }
    }
    private readonly static FrameworkPropertyMetadata ViewModelObjectMetadata = new FrameworkPropertyMetadata {
    };
    public static readonly DependencyProperty ViewModelObjectProperty = 
        DependencyProperty.Register("ViewModelObject", typeof(YourViewModel), typeof(ClientWindow), ViewModelObjectMetadata);
    #endregion
