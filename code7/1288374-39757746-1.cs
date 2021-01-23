    private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        // maybe do a column type check before..!?
        dgv.BeginEdit(false);
        var ec = dgv.EditingControl as DataGridViewComboBoxEditingControl;
        if (ec != null && ec.Width - e.X < SystemInformation.VerticalScrollBarWidth ) 
           ec.DroppedDown = true;
    }
