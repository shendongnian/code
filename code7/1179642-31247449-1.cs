    DateTime dt;
    GridView myGrid = new GridView();
    GridViewRow e = myGrid.SelectRow(0);
    string today = DateTime.Now.ToString("dd.MM.yyyy");
    int lastcol = e.Row.Cells.Count - 1;
    if (DateTime.TryParseExact(e.Row.Cells[lastcol].Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
    {
        string dtstr = dt.ToString("dd.MM.yyyy");
        if (dtstr != today)
        {
             for each(GridViewRow current in myGrid.Rows)
             {                 
                 current.Cells[lastcol].ForeColor = System.Drawing.Color.Red;
             }
        }
    }
