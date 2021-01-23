    public static readonly DependencyProperty StartDateProperty = 
    DependencyProperty.Register("StartDate", typeof(DateTime), typeof(ProgramWindow), new FrameworkPropertyMetadata(DateTime.MinValue),
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    
    public string StartDate
    {
        get
        {
            return this.GetValue(StartDateProperty) as DateTime;
        }
        set
        {
            this.SetValue(StartDateProperty, value);
        }
    }
