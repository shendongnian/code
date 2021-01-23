    for (var intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
    {
        var dateTime = Convert.ToDateTime(ds.Tables[0].Rows[intCount]["OrderDate"]);
        if (!dateTime.Day.ToString().Equals("7") && !dateTime.Month.ToString().Equals("7")) //Replace 7 with user input
        {
            ds.Tables[0].Rows[intCount].Delete();
        }
    }
    ds.AcceptChanges();
