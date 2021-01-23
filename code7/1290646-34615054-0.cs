    void radMultiColumnComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewDataRowInfo selectedRow = (GridViewDataRowInfo)radMultiColumnComboBox1.SelectedItem;
        Console.WriteLine(selectedRow.Cells["Id"].Value.ToString());
    }
