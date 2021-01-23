    public static string[] GetHeaderColumns(this ExcelWorksheet worksheet)
     {
            List<string> columnNames = new List<string>();
            foreach (var startRowCell in sheet.Cells[worksheet.Dimension.Start.Row, worksheet.Dimension.Start.Column, 1, worksheet.Dimension.End.Column])
                columnNames.Add(startRowCell.Text);
            return columnNames.ToArray();
      }
