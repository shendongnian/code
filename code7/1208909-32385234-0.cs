        if (col.Definition.Type == DataType.Double)
		{
				.....
					worksheet.Rows[r].Cells[column].CellFormat.FormatString = format;
		}
		else if (col.Definition.Type == DataType.DateTime)
		{
			...
				worksheet.Rows[r].Cells[column].Value = col[row];
		}
		else if (col.Definition.Type == DataType.Boolean)
		{
			...
			worksheet.Rows[r].Cells[column].Value = (bool) col[row];
		}
		else
		{
			// use string value, because some cell in the table is not a valid type in excel
			worksheet.Rows[r].Cells[column].Value = col[row].ToString();
		}
