    private int currentPrintingRowIndex = 0;
    private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
    {
        var allCheckedRows = this.myDataGridView.Rows.Cast<DataGridViewRow>()
                                    .Where(row => (bool?)row.Cells[0].Value == true)
                                    .ToList();
        if (allCheckedRows.Count > currentPrintingRowIndex)
        {
            var builder = new StringBuilder();
            var currentCheckedRow = allCheckedRows[currentPrintingRowIndex];
            var cellValues = currentCheckedRow.Cells.Cast<DataGridViewCell>()
                    .Where(cell => cell.ColumnIndex > 0)
                    .Select(cell => string.Format("{0}", cell.Value))
                    .ToArray();
            builder.AppendLine(string.Join(", ", cellValues));
            e.Graphics.DrawString(builder.ToString(),
                        this.myDataGridView.Font,
                        new SolidBrush(this.myDataGridView.ForeColor),
                        new RectangleF(0, 0, this.printDocument1.DefaultPageSettings.PrintableArea.Width, this.printDocument1.DefaultPageSettings.PrintableArea.Height));
            currentPrintingRowIndex += 1;
            e.HasMorePages = allCheckedRows.Count > currentPrintingRowIndex;
        }
    }
