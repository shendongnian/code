    public Uri Source2
        {
            get { return this.GetValue(SourceProperty2) as Uri; }
            set { SetValue(SourceProperty2, value); }
        }
    public static readonly DependencyProperty SourceProperty2 =
            DependencyProperty.Register("Source2",
            typeof(Uri), typeof(TabView),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
