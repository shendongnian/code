    public int SelectedRow = 0;
    private void dtgvCategory_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            // return if not StateChanged
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            // then you could put that row in a public variable
            SelectedRow = e.Row.Index;
        }
