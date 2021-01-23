    private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
    {
        //Find all checked rows
        var allCheckedRows = this.myDataGridView.Rows.Cast<DataGridViewRow>()
                                    .Where(row => (bool?)row.Cells[0].Value == true)
                                    .ToList();
        //create a stringBuilder that will contain the string for all checked rows
        var builder = new StringBuilder();
        //For each checked row, create string presentation of row and add to output stringBuilder
        allCheckedRows.ForEach(row =>
        {
            //Create an array of all cell value of a row to then concatenate them using a separator
            var cellValues = row.Cells.Cast<DataGridViewCell>()
                .Where(cell => cell.ColumnIndex > 0)
                .Select(cell => string.Format("{0}", cell.Value))
                .ToArray();
            //Then joiconcatenate values using ", " as separator, and added to output
            builder.AppendLine(string.Join(", ", cellValues));
            //Here instead of adding them to the stringBuilder, you can add int to another list.      
        });
        //Print the output string
        e.Graphics.DrawString(builder.ToString(),
                    this.myDataGridView.Font,
                    new SolidBrush(this.myDataGridView.ForeColor),
                    new RectangleF(0, 0, this.printDocument1.DefaultPageSettings.PrintableArea.Width, this.printDocument1.DefaultPageSettings.PrintableArea.Height));
    }
