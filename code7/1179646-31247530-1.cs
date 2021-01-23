    Well if you make a foreach that will do the thing :
    DateTime dt;
    string today = DateTime.Now.ToString("dd.MM.yyyy");
    int lastcol = e.Row.Cells.Count - 1;
    if (DateTime.TryParseExact(e.Row.Cells[lastcol].Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
    {
        string dtstr = dt.ToString("dd.MM.yyyy");
        if (dtstr != today)
        {
             foreach (Gridview a in idGridView.Rows)
        {
         a.Cells[7].ForeColor = System.Drawing.Color.Red
        }   
     }
    }
    
        
