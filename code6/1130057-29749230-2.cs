    string originalValue; // Define a global outside
        private void Gridview_Output_CellBeginEdit_1(object sender, DataGridViewCellCancelEventArgs e)
        {
            originalValue = Gridview_Output[e.ColumnIndex, e.RowIndex].Value.ToString();  
        }
