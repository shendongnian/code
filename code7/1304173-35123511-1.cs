    private void listboxPR_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cursor = Cursors.WaitCursor;
        string prnumberSelect;
        if (varname == 180)
        {
            //Somecode here for condition varname=180
            prnumberSelect = listboxPR.Text.ToString();
            Class1.fListItems(DataGridRequests, prnumberSelect);
            //Transferred code from DatagridRequests_SelectionChanged event
            if (DataGridRequests.RowCount > 0 ) {
                intVar1 = Convert.ToInt32(DataGridRequests.CurrentRow.Cells["column"].Value);
            }
        }
        else
        {
            prnumberSelect = listboxPR.Text.ToString();
            Class1.fListItems(DataGridRequests, prnumberSelect);
            if (DataGridRequests.RowCount > 0 ) {
                intVar1 = Convert.ToInt32(DataGridRequests.CurrentRow.Cells["column"].Value);
            }
        }
        Cursor = Cursors.Default;
    }
