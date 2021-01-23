    List<int> selected = DataGridView1.SelectedCells
                                      .Cast<DataGridViewCell>()
                                      .Select(cell => cell.RowIndex)
                                      .Distinct()
                                      .ToList();
    string Ids;
    foreach (int rowIndex in selected)
    {
        Ids += DataGridView1.Rows[rowIndex].Cells[0].Value + ", ";
    }
