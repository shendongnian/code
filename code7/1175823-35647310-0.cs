    for (int i = 0; i < tblData.Items.Count; ++i)
    {
        //(decimal.Parse((tblData.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text))
        sum += (decimal.Parse((tblData.Columns[3].GetCellContent(tblData.Items[i])as TextBlock).Text));
    }
