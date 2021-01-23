            public static DataTable MergeTables(DataTable dt1, DataTable dt2)
        {
            DataTable dt3 = dt1.Clone();
            foreach (DataColumn col in dt2.Columns)
            {
                string strColumnName = col.ColumnName;
                int intColNum = 1;
                while (dt3.Columns.Contains(strColumnName))
                {
                    strColumnName = string.Format("{0}_{1}", col.ColumnName, ++intColNum);
                }
                dt3.Columns.Add(strColumnName, col.DataType);
            }
            var Mergered = dt1.AsEnumerable().Zip(dt2.AsEnumerable(), (r1, r2) => r1.ItemArray.Concat(r2.ItemArray).ToArray());
            foreach (object[] rowFields in Mergered)
                dt3.Rows.Add(rowFields);
            return dt3;
        }
