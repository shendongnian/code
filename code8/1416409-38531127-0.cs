    Grid mainLayout = new Grid
    {
        VerticalOptions = LayoutOptions.FillAndExpand,
        RowDefinitions =
        {
            new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
            new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
        }
    };
    var _imageView = new Image
    {
        HorizontalOptions = LayoutOptions.FillAndExpand,
        VerticalOptions = LayoutOptions.FillAndExpand
    };
    Grid.SetRow(_imageView, 0); //_imageView will be added to the first row
    mainLayout.Children.Add(_imageView);
