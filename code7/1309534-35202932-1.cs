    var grid = new Grid()
    {
        RowSpacing = 12,
        ColumnSpacing = 12,
        VerticalOptions = LayoutOptions.FillAndExpand,
        RowDefinitions = Enumerable.Range(0, 100).Select(_ =>
            new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }),
        ColumnDefinitions = Enumerable.Range(.....
