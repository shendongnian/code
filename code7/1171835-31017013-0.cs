    public static readonly DependencyProperty _messTypeProperty =
        DependencyProperty.Register("_messType", typeof(String),
        typeof(MessageUC), new FrameworkPropertyMetadata(string.Empty));
    public String _messType
    {
        get { return GetValue(_messTypeProperty).ToString(); }
        set { SetValue(_messTypeProperty, value); }
    }
