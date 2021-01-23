    // Theres a million ways I'd rather do that
    public class DoubleClickEditDataGrid : DataGrid
    {
        protected override void OnCanExecuteBeginEdit(CanExecuteRoutedEventArgs e)
        {
            if (e.Parameter is MouseButtonEventArgs)
            {
                if ((e.Parameter as MouseButtonEventArgs).ClickCount <= 1)
                {
                    e.CanExecute = false;
                    return;
                }
            }
            base.OnCanExecuteBeginEdit(e);
        }
    }
