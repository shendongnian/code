            int countRows = dsgvKep1 .Tables[0].Rows.Count;
            int dummyRecords = 0;
            if(countRows < 15)
            {
                dummyRecords = 15 - countRows;
            }
            for (int i = 0; i < dummyRecords; i++)
            {
                DataTable tbl = dsgvKep1.Tables[0];
                DataRow row = tbl.NewRow();
                //add dummy values if you want
                //row["ColumnName"] = value;
                tbl.Rows.Add(row);
            }
