    private DependencyObject CreatePin()
        {
            //Creating a Grid element.
            var myGrid = new Grid();
            myGrid.RowDefinitions.Add(new RowDefinition());
            myGrid.RowDefinitions.Add(new RowDefinition());
            myGrid.ColumnDefinitions.Add(new ColumnDefinition());
            myGrid.ColumnDefinitions.Add(new ColumnDefinition());
            myGrid.Background = new SolidColorBrush(Colors.Transparent);
            //Creating a Rectangle
            var myRectangle = new Rectangle {Fill = new SolidColorBrush(Colors.Blue), Height = 20, Width = 20};
            myRectangle.SetValue(Grid.RowProperty, 0);
            myRectangle.SetValue(Grid.ColumnProperty, 0);
            //Adding the Rectangle to the Grid
            myGrid.Children.Add(myRectangle);
            //Creating a Polygon
            var myPolygon = new Polygon()
            {
                Points = new PointCollection() {new Point(2, 0), new Point(22, 0), new Point(2, 40)},
                Stroke = new SolidColorBrush(Colors.Blue),
                Fill = new SolidColorBrush(Colors.Blue),
            };
            myPolygon.SetValue(Grid.RowProperty, 1);
            myPolygon.SetValue(Grid.ColumnProperty, 0);
            TextBlock newtextblock = new TextBlock();
            newtextblock.Text = "hello";
            newtextblock.FontSize = 15;
            newtextblock.Foreground = new SolidColorBrush(Colors.Blue);
            newtextblock.SetValue(Grid.RowProperty, 0);
            newtextblock.SetValue(Grid.ColumnProperty, 1);
            myGrid.Children.Add(newtextblock);
            //Adding the Polygon to the Grid
            myGrid.Children.Add(myPolygon);
            return myGrid;
        }
