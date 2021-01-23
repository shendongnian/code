    int row = 3;
    int column = 2;
    var image = grid.Children.OfType<Image>().FirstOrDefault(i => Grid.GetRow(grid) == row && Grid.GetColumn(grid) == column);
    if (image != null)
    {
        // Found the picture on line 3 and column 2
    }
