    ...
    private static readonly int COLUMS = 5;
    ...
    comboColors.ItemsSource = typeof(Colors).GetProperties();
    ...
    private void table_Loaded(object sender, RoutedEventArgs e) {
        Grid grid = sender as Grid;
        if (grid != null) {
            if (grid.RowDefinitions.Count == 0) {
                for (int r = 0; r <= comboColors.Items.Count / COLUMS; r++) {
                    grid.RowDefinitions.Add(new RowDefinition());
                }
            }
            if (grid.ColumnDefinitions.Count == 0) {
                for (int c = 0; c < Math.Min(comboColors.Items.Count, COLUMS); c++) {
                    grid.ColumnDefinitions.Add(new ColumnDefinition());
                }
            }
            for (int i = 0; i < grid.Children.Count; i++) {
                Grid.SetColumn(grid.Children[i], i % COLUMS);
                Grid.SetRow(grid.Children[i], i / COLUMS);
            }
        }
    }
