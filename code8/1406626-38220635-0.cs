	#region SelectionChangedCommand 
    public ICommand SelectionChangedCommand
    {
        get { return (ICommand)GetValue(SelectionChangedCommandProperty); }
        set { SetValue(SelectionChangedCommandProperty, value); }
    }
    private readonly static FrameworkPropertyMetadata SelectionChangedCommandMetadata = new FrameworkPropertyMetadata {
        DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
    };
    public static readonly DependencyProperty SelectionChangedCommandProperty = 
        DependencyProperty.Register("SelectionChangedCommand", typeof(ICommand), typeof(ToolboxView), SelectionChangedCommandMetadata);
    #endregion
      
    #region SelectionChangedCommandParameter 
    public Object SelectionChangedCommandParameter
    {
        get { return (Object)GetValue(SelectionChangedCommandParameterProperty); }
        set { SetValue(SelectionChangedCommandParameterProperty, value); }
    }
    private readonly static FrameworkPropertyMetadata SelectionChangedCommandParameterMetadata = new FrameworkPropertyMetadata {
        DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
    };
    public static readonly DependencyProperty SelectionChangedCommandParameterProperty = 
        DependencyProperty.Register("SelectionChangedCommandParameter", typeof(Object), typeof(ToolboxView), SelectionChangedCommandParameterMetadata);
    #endregion
