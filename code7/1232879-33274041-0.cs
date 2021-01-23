    private async void RenewDataGrid_OnCellUpdated(object sender, CellUpdatedEventArgs e)
    {
        row.Cells[4].IsEnabled = false;
        DoEvents();
        await datacontext.CalculateFdtotalAmount();
        DoEvents();
        row.Cells[4].IsEnabled = true;
    }
 
        public object ExitFrame(object f)
        {
            ((DispatcherFrame)f).Continue = false;
            return null;
        }
        public void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                new DispatcherOperationCallback(ExitFrame), frame);
            Dispatcher.PushFrame(frame);
        }
