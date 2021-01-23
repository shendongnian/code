            DataTable dt = new DataTable();
            dt.Columns.Add("Agent");
            dt.Columns.Add("Product1");
            dt.Columns.Add("Product2");
            DataRow dr = dt.NewRow();
            dr[0] = "AA";
            dr[1] = 7;
            dr[2] = 5;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "AA";
            dr[1] = 5;
            dr[2] = 6;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "BB";
            dr[1] = 2;
            dr[2] = 3;
            dt.Rows.Add(dr);
       
     DataView view = new DataView(dt);
            DataTable dtDaysInDocument = view.ToTable(true, "Agent");**//Used to distinct column value**
            string[] dateRecord = dtDaysInDocument.Rows.Cast<DataRow>()
                                .Select(row => row["Agent"].ToString())
                                .ToArray();
            DataTable dtFinal = new DataTable();
            dtFinal = dt.Clone();
            foreach (string str in dateRecord)
            {
                DataRow[] rows = dt.Select("Agent='" + str + "'");
                if (rows.Length > 1)
                {
                    int finalValue = 0;
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.ColumnName != "Agent")
                        {
                            foreach (DataRow row in rows)
                            {
                                int colValue = row[col] != null ? Convert.ToInt16(row[col]) : 0;
                                finalValue = colValue;
                                DataRow[] dtFinalrows = dtFinal.Select("Agent='" + str + "'");
                                if (dtFinalrows.Length == 1)
                                {
                                    string val = dtFinalrows[0][col.ColumnName].ToString();
                                    if (val != "")
                                        finalValue = finalValue + Convert.ToInt16(val);
                                    dtFinalrows[0][col.ColumnName] = finalValue;
                                }
                                else
                                {
                                    DataRow finalDr = dtFinal.NewRow();
                                    finalDr[col.ColumnName] = finalValue;
                                    finalDr["Agent"] = str;
                                    dtFinal.Rows.Add(finalDr);
                                }
                            }
                        }
                    }
                }
                else if (rows.Length == 1)
                {
                    DataRow finalDr = dtFinal.NewRow();
                    foreach (DataColumn col in dt.Columns)
                    {
                        finalDr[col.ColumnName] = rows[0][col.ColumnName];
                    }
                    dtFinal.Rows.Add(finalDr);
                }
