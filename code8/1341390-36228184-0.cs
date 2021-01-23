        private void dgvListItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                DataGridViewTextBoxEditingControl tb = e.Control as DataGridViewTextBoxEditingControl;
                tb.PreviewKeyDown -= dgvListItems_PreviewKeyDown;
                tb.PreviewKeyDown += dgvListItems_PreviewKeyDown;
            }
        }
        private void dgvListItems_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                int columnIndex = dgvListItems.CurrentCell.ColumnIndex; ;
                int rowIndex = dgvListItems.CurrentCell.RowIndex;
                if (columnIndex == dgvListItems.Columns.Count - 1)
                {
                    dgvListItems.CurrentCell = dgvListItems[0, rowIndex + 1];
                }
                else
                {
                    dgvListItems.CurrentCell = dgvListItems[columnIndex + 1, rowIndex];
                }
            }
        }
