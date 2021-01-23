    foreach (var item in _model.SelectedItems)
    {
        var row = new DataGridViewRow();
        var codeCell = new DataGridViewComboBoxCell();
        codeCell.Items.AddRange(ItemCode.Items);
        codeCell.Value = ItemCode.Items.GetListItem(item.Code);
        var nameCell = new DataGridViewComboBoxCell();
        nameCell.Items.AddRange(ItemName.Items);
        nameCell.Value = ItemName.Items.GetListItem(item.Name);
        row.Cells.Add(new DataGridViewTextBoxCell { Value = item.Id });
        row.Cells.Add(codeCell);
        row.Cells.Add(nameCell);
        row.Cells.Add(new DataGridViewTextBoxCell { Value = item.Units });
        row.Cells.Add(new DataGridViewTextBoxCell { Value = item.Quantity });
        row.Cells.Add(new DataGridViewTextBoxCell { Value = item.PriceLt });
        row.Cells.Add(new DataGridViewTextBoxCell { Value = item.PriceEu });
        itemView.Rows.Add(row);
    }
