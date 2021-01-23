    DateTime dt;
    GridView myGrid = new GridView();
    GridViewRow e = myGrid.SelectRow(0);
    int lastcol = e.Row.Cells.Count - 1;
    if (DateTime.TryParseExact(e.Row.Cells[lastcol].Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
    {
        if (dt > DateTime.Now)
        {
             for each(GridViewRow current in myGrid.Rows)
             {                 
                 current.Cells[lastcol].ForeColor = System.Drawing.Color.Red;
             }
        }
    }
