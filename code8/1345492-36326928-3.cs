    // This code goes to the button click
    for (int i = 0; i < PTable.SelectedRows.Count; i++)
    {
        productids[i].Text = PTable.SelectedRows[i].Cells[0].Value.ToString();
    }
