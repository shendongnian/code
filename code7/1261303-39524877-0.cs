    public static readonly DependencyProperty OutputSourceCollectionProperty 
        = DependencyProperty.Register("OutputSourceCollection",
            typeof(IEnumerable), 
            typeof(BListBox), 
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    
    public IEnumerable OutputSourceCollection
    {
        get { return (IEnumerable)GetValue(OutputSourceCollectionProperty); }
        set { SetValue(OutputSourceCollectionProperty, value); }
    }
