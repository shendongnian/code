    private void Button1_Click(object sender, EventArgs e)
    {
        PrintDocument1.Print();
    }
    PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
    {
        var firstCheckedRow = this.myDataGridView.Rows.Cast<DataGridViewRow>()
                                  .Where(row => (bool?)row.Cells["MyCheckBoxColumn"].Value == true)
                                  .FirstOrDefault();
        var builder = new StringBuilder();
        firstCheckedRow.Cells.Cast<DataGridViewCell>()
                       .ToList().ForEach(cell =>
                       {
                           builder.AppendLine(string.Format("{0}", cell.Value));
                       });
    
        e.Graphics.DrawString(builder.ToString(),
                   this.myDataGridView.Font,
                   new SolidBrush(this.myDataGridView.ForeColor),
                   new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));
    }
