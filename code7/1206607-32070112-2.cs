    var grid = new Grid
    {
        ColumnDefinitions =
            {
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition()
            }
    };
    var rectangle1 = new Rectangle { Fill = Brushes.Blue };
    rectangle1.SetValue(Grid.ColumnProperty, 0);
    grid.Children.Add(rectangle1);
    var rectangle2 = new Rectangle { Fill = Brushes.Red };
    rectangle2.SetValue(Grid.ColumnProperty, 1);
    grid.Children.Add(rectangle2);
    var rectangle3 = new Rectangle { Fill = Brushes.Green };
    rectangle3.SetValue(Grid.ColumnProperty, 2);
    grid.Children.Add(rectangle3);
    var rectangle4 = new Rectangle { Fill = Brushes.Yellow };
    rectangle4.SetValue(Grid.ColumnProperty, 3);
    grid.Children.Add(rectangle4);
