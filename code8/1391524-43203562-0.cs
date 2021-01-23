    var grid = new Grid();
    grid.HorizontalOptions = LayoutOptions.Fill;
    grid.VerticalOptions = LayoutOptions.Start;
    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
    grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto, });
    
    var minSizer = new BoxView();
    minSizer.HeightRequest = 30;
    grid.Children.Add(minSizer, 0, 0);
    
     _label = new Label();
    _label.VerticalTextAlignment = TextAlignment.Center;
    _label.VerticalOptions = LayoutOptions.Center;
    grid.Children.Add(_label, 0, 0);
    
    ...
