        public DataTable CustomTable(DataTable excelTable)
        {
            var table = new DataTable();
            var col0 = table.Columns.Add("Name", typeof(String));
            var col1 = table.Columns.Add("Age", typeof(int));
            var col2 = table.Columns.Add("Arabic Name", typeof(String));
            var col3 = table.Columns.Add("Category", typeof(String));
            var ok = false;
            for (var index = 0; index < excelTable.Rows.Count; index++)
            {
                DataRow excelRow = excelTable.Rows[index];
                if (ok)
                {
                    DataRow row = table.NewRow();
                    row[col0] = String.Format("{0}", excelRow["Name"]);
                    row[col1] = Convert.ToInt32(excelRow["Age"]);
                    row[col2] = String.Format("{0}", excelRow["Arabic Name"]);
                    row[col3] = String.Format("{0}", excelRow["Category"]);
                    table.Rows.Add(row);
                }
                else
                {
                    ok = (excelRow[0].ToString() == "Name");
                }
            }
            return table;
        }
