    void radGridView1_CellValueChanged(object sender, GridViewCellEventArgs e)
    {
        RadMultiColumnComboBoxElement mccbEditor = (RadMultiColumnComboBoxElement)e.ActiveEditor;
        GridViewDataRowInfo selectedRow = (GridViewDataRowInfo)mccbEditor.SelectedItem;
        Console.WriteLine(selectedRow.Cells["Id"].Value.ToString());
    }
    void radGridView1_ValueChanged(object sender, EventArgs e)
    {
        RadMultiColumnComboBoxElement mccbEditor = (RadMultiColumnComboBoxElement)radGridView1.ActiveEditor;
        GridViewDataRowInfo selectedRow = (GridViewDataRowInfo)mccbEditor.SelectedItem;
        Console.WriteLine(selectedRow.Cells["Id"].Value.ToString());
    }
