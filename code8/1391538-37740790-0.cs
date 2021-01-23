    public MainWindow()
    {
        InitializeComponent();
    
        Grid grid1 = new Grid();
        grid1.ColumnDefinitions.Add(new ColumnDefinition());
        grid1.ColumnDefinitions.Add(new ColumnDefinition());
    
        Content = grid1;
    
        Grid grid2 = new Grid();
        grid2.SetValue(Grid.ColumnProperty, 1);
        grid2.ColumnDefinitions.Add(new ColumnDefinition());
        grid2.ColumnDefinitions.Add(new ColumnDefinition());
    
        grid1.Children.Add(grid2);
    
        Label label = new Label {Content = "Label"};
        label.SetValue(Grid.ColumnProperty, 1);
    
        grid2.Children.Add(label);
    }
