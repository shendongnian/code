    var grid = new Grid ();
    grid.RowDefinitions.Add (new RowDefinition { Height = GridLength.Auto });
    grid.RowDefinitions.Add (new RowDefinition { Height = new GridLength (1, GridUnitType.Star) });
    var stacklayout1 = new StackLayout { HeightRequest = 100, BackgroundColor = Color.Red };
    var stacklayout2 = new StackLayout { BackgroundColor = Color.Blue };
    Grid.SetRow (stacklayout2, 1);
    grid.Children.Add (stacklayout1);
    grid.Children.Add (stacklayout2);
    MainPage = new ContentPage { Content = grid };  
