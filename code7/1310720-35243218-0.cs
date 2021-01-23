    public static readonly DependencyProperty SourceAProperty =
        DependencyProperty.Register("SourceA", typeof(IEnumerable), typeof(NexusEditor), 
        new FrameworkPropertyMetadata(Source_PropertyChanged));
    public static readonly DependencyProperty SourceBProperty =
        DependencyProperty.Register("SourceB", typeof(IEnumerable), typeof(NexusEditor),
        new FrameworkPropertyMetadata(Source_PropertyChanged));
