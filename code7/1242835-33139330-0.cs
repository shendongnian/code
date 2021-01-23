        public static DataTable Dedup(this DataTable dt, string columnName)
        {
            for (int rowIndex = dt.Rows.Count - 1; rowIndex >= 1; rowIndex--)
            {
                var row = dt.Rows[rowIndex][columnName];
                var previousRow = dt.Rows[rowIndex - 1][columnName];
                if (row.ToString() == previousRow.ToString())
                {
                    dt.Rows[rowIndex][columnName] = "";
                }
            }
            return dt;
        }
