            Dictionary<int,String> columnNames = new Dictionary<int,string>();
            int index = 0;
            foreach (DataRow row in schema.Rows) {
                columnNames.Add(index,row[schema.Columns["ColumnName"]].ToString());
                index++;
            }
