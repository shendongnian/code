        var sBuilder = new StringBuilder();
        sBuilder.Append(";");
        // ColumnsHeader
        foreach (DataGridViewColumn column in gvReport.Columns)
        {
            sBuilder.Append(String.Concat(column.HeaderText, ";"));
        }
        foreach (DataGridViewRow row in gvReport.Rows)
        {
            // RowHeader
            sBuilder.Append(String.Concat(row.HeaderCell.Value, ";"));
            // Cells
            foreach (DataGridViewCell cell in row.Cells)
            {
                sBuilder.Append(String.Concat(cell.Value, ";"));
            }
            sBuilder.Append(Environment.NewLine);
        }
