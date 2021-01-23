    public static readonly DependencyProperty ExpandedContentProperty =
        DependencyProperty.Register(
            nameof(ExpandedContent),
            typeof(Object),
            typeof(ExpandableListView),
            new PropertyMetadata(null));
