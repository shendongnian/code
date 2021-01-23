    private Grid CreateGrid()
        {
            var LayoutGrid = new Grid { Background = new SolidColorBrush(Colors.Yellow) };
            //Created Two Columns
            LayoutGrid.ColumnDefinitions.Add(new ColumnDefinition());
            LayoutGrid.ColumnDefinitions.Add(new ColumnDefinition());
            //Created Two Rows
            LayoutGrid.RowDefinitions.Add(new RowDefinition());
            LayoutGrid.RowDefinitions.Add(new RowDefinition());
            // region 1
            var stack1 = new StackPanel {
                Background = new SolidColorBrush(Colors.Red)
            };
            Grid.SetColumn(stack1, 0);
            Grid.SetRowSpan(stack1, 2);
            LayoutGrid.Children.Add(stack1);
            // region 2
            var stack2 = new StackPanel
            {
                Background = new SolidColorBrush(Colors.Green)
            };
            Grid.SetColumn(stack2, 1);
            LayoutGrid.Children.Add(stack2);
            // region 2
            var stack3 = new StackPanel
            {
                Background = new SolidColorBrush(Colors.Blue)
            };
            Grid.SetColumn(stack3, 1);
            Grid.SetRow(stack3, 1);
            LayoutGrid.Children.Add(stack3);
            return LayoutGrid;
        }
