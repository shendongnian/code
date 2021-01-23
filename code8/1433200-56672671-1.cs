    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
    
        int colCount = mainGrid.ColumnDefinitions.Count;
        int rowCount = mainGrid.RowDefinitions.Count;
    
        if (colCount > 0 && rowCount > 0)
        {
            mainGrid.HeightRequest = (firstCell.Width + mainGrid.RowSpacing) * rowCount - mainGrid.RowSpacing;
        }
    }
