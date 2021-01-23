    using Utils;
    
    class MyCode
    {
        public static DataGridCellsPresenter GetPresenter(DataGridRow row)
        {
            return row.FindVisualChild<DataGridCellsPresenter>();
        }
    }
