    DataGridView view = new DataGridView();
    for (int i = 0; i < view.SelectedRows.Count; i++)
    {
        productids[i].Text = view.SelectedRows[i].Cells[0].Value.ToString();
    }
