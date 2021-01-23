            DataTable dt = ds.Tables[0];
            DataTable dt2 = dt.Clone();
            int count = 5;
            int currCount = 0;
            int tableSr = 2;
            dt.Rows.OfType<DataRow>().ToList().ForEach(x =>
            {
                currCount++;
                dt2.ImportRow(x);
                if (currCount == count)
                {
                    currCount = 0;
                    dt2.TableName = "Table" + tableSr;
                    tableSr++;
                    ds.Tables.Add(dt2);
                    dt2 = dt.Clone();
                }
                if ((dt.Rows.Count - 1) == dt.Rows.IndexOf(x))
                {
                    dt2.TableName = "Table" + tableSr;
                    ds.Tables.Add(dt2);
                }
            });
