    public MainPage()
    {
        this.InitializeComponent();
        DataContext = this;
        Loaded += MainPage_Loaded;
    }
    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        Grid gameboard = new Grid();
        gameboard.HorizontalAlignment = HorizontalAlignment.Stretch;
        gameboard.VerticalAlignment = VerticalAlignment.Stretch;
        for (int j = 0; j < 7; j++)
        {
            var cd = new ColumnDefinition();
            cd.Width = new GridLength(1, GridUnitType.Star);
            var rd = new RowDefinition();
            rd.Height = new GridLength(1, GridUnitType.Star);
            gameboard.ColumnDefinitions.Add(cd);
            gameboard.RowDefinitions.Add(rd);
        }
        for (int j = 0; j < 7; j++)
        {
            for (int i = 0; i < 7; i++)
            {
                Border border = new Border();
                border.BorderThickness = new Thickness(1);
                border.BorderBrush = new SolidColorBrush(Colors.Blue);
                border.HorizontalAlignment = HorizontalAlignment.Stretch;
                border.VerticalAlignment = VerticalAlignment.Stretch;
                var tb = new TextBlock();
                tb.Text = string.Format($"i={i}; j={j}");
                tb.Margin = new Thickness(4);
                Grid.SetColumn(border, j);
                Grid.SetRow(border, i);
                border.Child = tb;
                gameboard.Children.Add(border);
            }
        }
        LayoutRoot.Children.Add(gameboard);
    }
