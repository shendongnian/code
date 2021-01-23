    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        double colsCount = MainGrid.ColumnDefinitions.Count;
        double rowsCount = MainGrid.RowDefinitions.Count;
        if (colsCount > 0 & rowsCount > 0)
        {
            MainGrid.HeightRequest = width / colsCount * rowsCount;
        }
    }
