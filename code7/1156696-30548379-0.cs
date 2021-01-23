    YourDataTable.RowDeleted += new DataRowChangeEventHandler(dataTable_RowChanged);
        private void dataTable_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataRow _dr = e.Row as DataRow;
            try
            {
                if (e.Row.RowState == DataRowState.Deleted)
                {
                  // YOUR CODE
                }
                if (e.Row.RowState == DataRowState.Added) { //OPTIONAL }
                if (e.Row.RowState == DataRowState.Modified) { //OPTIONAL}
            }
            catch (Exception ex) { }
            finally { _dr = null; }
        }
