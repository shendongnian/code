    var temp = new Grid
    {
        RowSpacing = 12,
        ColumnSpacing = 12,
        VerticalOptions = LayoutOptions.FillAndExpand,
    };
    
    for (int index = 0; index < rowCount; index++)
        temp.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
    ... same for columns
    var grid = temp;
