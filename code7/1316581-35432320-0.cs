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
            dr[0] = "BB";
            dr[1] = 5;
            dr[2] = 6;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "BB";
            dr[1] = 2;
            dr[2] = 3;
            dt.Rows.Add(dr);
            StringBuilder sb = new StringBuilder();
            string[] columnNames = dt.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName).
                                              ToArray();
            sb.AppendLine(string.Join(",", columnNames));
            foreach (DataRow row in dt.Rows)
            {
                string[] fields = row.ItemArray.Select(field => field.ToString()).
                                                ToArray();
                sb.AppendLine(string.Join(",", fields));
            }
            File.WriteAllText(@"C:\Users\Desktop\test.csv", sb.ToString());
