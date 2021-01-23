    public MainPage()
    {
        InitializeComponent();
        Instance = this;
        Loaded += MainPage_Loaded;
    }
    private void MainPage_Loaded(object sender, RoutedEventArgs args)
    {
        var xaml = " <DataTemplate xmlns:local=\"using:App1\"                              "
                    + "  xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"> "
                    + "     <Grid Margin=\"4\" Width=\"150\" Height=\"100\"                   "
                    + "      local:MainPage.CustomLoaded=\"true\">                            "
                    + "         <Grid.Background>                                             "
                    + "             <SolidColorBrush Color=\"{Binding}\" />                   "
                    + "         </Grid.Background>                                            "
                    + "     </Grid>                                                           "
                    + " </DataTemplate>                                                       ";
        MyItemsControl.ItemTemplate = XamlReader.Load(xaml) as DataTemplate;
        MyItemsControl.ItemsSource = new[] { Colors.Red, Colors.Green, Colors.Blue, Colors.Orange, Colors.Purple };
    }
    private static MainPage Instance { get; set; }
    public static bool GetCustomLoaded(DependencyObject obj) { return (bool)obj.GetValue(CustomLoadedProperty); }
    public static void SetCustomLoaded(DependencyObject obj, bool value) { obj.SetValue(CustomLoadedProperty, value); }
    public static readonly DependencyProperty CustomLoadedProperty =
        DependencyProperty.RegisterAttached("CustomLoaded", typeof(bool),
            typeof(MainPage), new PropertyMetadata(null, (d, e) => Instance.GridLoaded((d as Grid))));
    private void GridLoaded(Grid grid)
    {
        grid.ManipulationMode = ManipulationModes.All;
        grid.ManipulationDelta += Grid_ManipulationDelta;
    }
    private void Grid_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
    {
        // TODO
    }
