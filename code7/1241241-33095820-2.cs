        private void DataGridInvoiceRowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit) {
                Invoice invoice = e.Row.DataContext as Invoice;
                // update Invoice object if needed
                if (invoice != null)
                {
                    // ....
                }
            }
        }
        private void DataGridInvoiceCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
           // ...
        }
