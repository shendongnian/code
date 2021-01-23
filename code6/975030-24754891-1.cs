    TableHeaderCell tableHeaderCell = new TableHeaderCell();
    try
    {
        tableHeaderCell.Text = "Total Commission";
        tableHeaderCell.ColumnSpan = 1;
        tableHeaderCell.HorizontalAlign = HorizontalAlign.Center;
        tableHeaderCell.VerticalAlign = VerticalAlign.Middle;
        e.Row.Cells.AddAt(0, tableHeaderCell);
    }
    catch
    {
        tableHeaderCell.Dispose();
        throw;
    }
