        private DataTable m_table;
        public DataTable GetData(string sqlCmd)
        {
            DataTable table = new DataTable();
            return table;
        }
        public DataTable GetData(DataTable table, string sqlFilter)
        {
            if (!String.IsNullOrEmpty(sqlFilter))
            {
                var copy = table.Clone();
                foreach (DataRow row in table.Select(sqlFilter))
                {
                    var newRow = copy.NewRow();
                    for (int i = 0; i < row.ItemArray.Length; i++)
                    {
                        newRow[i] = row.ItemArray[i];
                    }
                    copy.Rows.Add(newRow);
                }
                return copy;
            }
            return table;
        }
