	//foreach (var firstRowCell in ws.Cells[10, 1, 17, ws.Dimension.End.Column])  -- ASSUME YOU MEANT ONLY THE 10TH ROW?
	foreach (var firstRowCell in ws.Cells[10, 1, 10, ws.Dimension.End.Column])
	{
		if (!hasHeader)
			tbl.Columns.Add(string.Format("Column {0}", firstRowCell.Start.Column));
		else if(firstRowCell.Text == "Description")
			tbl.Columns.Add("Edata");
		else if (firstRowCell.Text == "Column4")
			tbl.Columns.Add("Description");
		else
			tbl.Columns.Add(firstRowCell.Text);
	}
	var startRow = hasHeader ? 11 : 1;
	for (var rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
	{
		//Skip row if last column is null
		if (ws.Cells[rowNum, ws.Dimension.End.Column].Value == null)
			continue;
		var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
		var row = tbl.NewRow();
		foreach (var cell in wsRow)
		{
			row[cell.Start.Column - 1] = cell.Text;
		}
		tbl.Rows.Add(row);
	}
