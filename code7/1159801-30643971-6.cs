        int rowCountPerTable = 5; //Number of tables would be based on this
        int currPos = 0;
        DataTable dt = ds.Tables[0];
        DataTable tempDt = dt.Clone();
        dt.Rows.OfType<DataRow>().ToList().ForEach(x =>
        {
            currPos++;
            tempDt.ImportRow(x);
            if (currPos == rowCountPerTable)
            {
                currPos = 0;
                tempDt.TableName = "Table" + (ds.Tables.Count + 1);
                ds.Tables.Add(tempDt);
                tempDt = dt.Clone();
            }
            else if ((dt.Rows.Count - 1) == dt.Rows.IndexOf(x))
            {
                tempDt.TableName = "Table" + (ds.Tables.Count + 1);
                ds.Tables.Add(tempDt);
            }
        });
