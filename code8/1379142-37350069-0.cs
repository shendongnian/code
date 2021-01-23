    public static DataTable convertStringToDataTable(string data)
        {
            DataTable dataTable = new DataTable();
            bool columnsAdded = false;
            foreach (string row in data.Split('\n'))
            {
                DataRow dataRow = dataTable.NewRow();
                string[] cell = row.Split(',');
                for (int i = 0; i < cell.Length; i++)
                {
                    string[] keyValue = cell[i].Split('"');
                    if (!columnsAdded)
                    {
                        DataColumn dataColumn = new DataColumn();
                        dataTable.Columns.Add(dataColumn);
                    }
                    dataRow[i] = keyValue[1];
                }
                columnsAdded = true;
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }
