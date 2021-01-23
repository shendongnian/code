    public class ExtendedDataGrid : DataGrid
    {
        public ExtendedDataGrid()
        {
            Loaded += (sender, args) => RefreshRowNumbers();
        }
        protected override void OnExecutedDelete(ExecutedRoutedEventArgs e)
        {
            base.OnExecutedDelete();
            RefreshRowNumbers();
        }
        private void RefreshRowNumbers()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                var row = (DataGridRow)ItemContainerGenerator.ContainerFromIndex(i);
                row.Header = ((row.GetIndex()) + 1).ToString();
            } 
        }
    }
