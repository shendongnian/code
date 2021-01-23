    private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
    {
        var allCheckedRows = this.myDataGridView.Rows.Cast<DataGridViewRow>()
                                    .Where(row => (bool?)row.Cells[0].Value == true)
                                    .ToList();
        var builder = new StringBuilder();
        allCheckedRows.ForEach(row =>
        {
            var cellValues = row.Cells.Cast<DataGridViewCell>()
                .Where(cell => cell.ColumnIndex > 0)
                .Select(cell => string.Format("{0}", cell.Value))
                .ToArray();
            builder.AppendLine(string.Join(", ", cellValues));
        });
        e.Graphics.DrawString(builder.ToString(),
                    this.myDataGridView.Font,
                    new SolidBrush(this.myDataGridView.ForeColor),
                    new RectangleF(0, 0, this.printDocument1.DefaultPageSettings.PrintableArea.Width, this.printDocument1.DefaultPageSettings.PrintableArea.Height));
    }
