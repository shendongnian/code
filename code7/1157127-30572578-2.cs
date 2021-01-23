    int row = 3;
    int column = 2;
    var image = grid.Children.OfType<Image>().FirstOrDefault(i => Grid.GetRow(i) == row && Grid.GetColumn(i) == column);
    if (image != null)
    {
        // Found the picture on line 3 and column 2
    }
