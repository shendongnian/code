    class SqlInHelper
    {
        public static string AddTags (DataColumn col)
        {
            string colName = col.ColumnName;
            string addStr = "";
            int distinct = (from DataRow row in col.Table.Rows
                       select row[colName]).Distinct().Count();
            for(int i=0;i<distinct;i++)
            {
                addStr += "@" + colName + i + ", ";
            }
            
            return addStr.Substring(0, addStr.Length - 2); // remove last ", "
        }
        public static void AddParams(SqlCommand query, DataColumn col, out bool bValid)
        {
            string colName = col.ColumnName;
            var vals = (from DataRow row in col.Table.Rows
                            select row[colName]).Distinct().ToArray();
            if (query.CommandText.Contains("@" + colName + (vals.Length - 1))) {
                for (int i = 0; i < vals.Length; i++)
                {
                    query.Parameters.AddWithValue("@" + colName + i, Convert.ChangeType(vals[i], col.DataType));
                }
                bValid = true;
            } else {
                bValid = false;
            }
        }
    }
