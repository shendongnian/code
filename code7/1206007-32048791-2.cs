    public static readonly DependencyProperty RowProperty =
        DependencyProperty.RegisterAttached("Row", typeof(int), typeof(GameBoardPanel),
            new FrameworkPropertyMetadata(0,
                FrameworkPropertyMetadataOptions.AffectsParentArrange));
    public static readonly DependencyProperty ColumnProperty =
        DependencyProperty.RegisterAttached("Column", typeof(int), typeof(GameBoardPanel),
            new FrameworkPropertyMetadata(0,
                FrameworkPropertyMetadataOptions.AffectsParentArrange));
