    // This code goes to the button click
    for (int i = 0; i < PTable.SelectedRows.Count; i++)
    {
        productids[i].Text = PTable.SelectedRows[i].Cells[0].Value.ToString();
        productnames[i].Text = PTable.SelectedRows[i].Cells[1].Value.ToString();
        // or better... Name the columns
        // unitprices[i].Text = PTable.SelectedRows[i].Cells["unitPrices"].Value.ToString();
        unitprices[i].Text = PTable.SelectedRows[i].Cells[4].Value.ToString();
    }
