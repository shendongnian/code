    if (DateTime.TryParseExact(e.Row.Cells[lastcol].Text, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
    {
        string dtstr = dt.ToString("dd.MM.yyyy");
        if (dtstr != today)
        {
            e.Row.Cells[lastcol].ForeColor = System.Drawing.Color.Red;
            foreach (GridViewRow row in GridView1.Rows)
            {
                row.Cells[lastcol].ForeColor = System.Drawing.Color.Red;
            }
        }
    }
