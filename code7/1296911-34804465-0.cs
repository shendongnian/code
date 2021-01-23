    T GetChildForRowColumn<T>(Grid grid, int row, int column)
    {
        foreach (Rectangle child in grid.Children.OfType<T>())
        {
            if (Grid.GetRow(child) == row && Grid.GetColumn(child) == column)
            {
                return child;
            }
        }
    }
