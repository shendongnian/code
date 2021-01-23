        DataTable tempDt = new DataTable();
        tempDt = ds.Tables[0].Clone();
        ds.Tables[0].Rows.OfType<DataRow>().ToList().ForEach(x =>
        {
            if (Convert.ToInt16(x["ID"]) == Convert.ToInt16(Winners[ds.Tables[0].Rows.IndexOf(x), 0]))
            {
                tempDt.ImportRow(x);
            }
        });
        DataSet dsWinners = new DataSet();
        dsWinners.Tables.Add(tempDt);
