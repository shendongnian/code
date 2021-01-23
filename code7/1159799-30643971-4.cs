        int rowCountPerTable = 5; //Number of tables could be calculated from this
        int currPos = 0;
        int tableSr = 2; //To track the table number
        DataTable dt = ds.Tables[0];
        DataTable tempDt = dt.Clone();
        dt.Rows.OfType<DataRow>().ToList().ForEach(x =>
        {
            currPos++;
            tempDt.ImportRow(x);
            if (currPos == rowCountPerTable)
            {
                currPos = 0;
                tempDt.TableName = "Table" + tableSr;
                ds.Tables.Add(tempDt);
                tableSr++;
                tempDt = dt.Clone();
            }
            else if ((dt.Rows.Count - 1) == dt.Rows.IndexOf(x))
            {
                tempDt.TableName = "Table" + tableSr;
                ds.Tables.Add(tempDt);
            }
        });
