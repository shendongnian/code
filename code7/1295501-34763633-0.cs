    public static void DataBaseToExcel(string connectionString, string table, string saveAs)
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook workbook = app.Workbooks.Add(System.Reflection.Missing.Value);
            app.ActiveWindow.DisplayGridlines = false;
            Excel.Worksheet worksheet = workbook.Worksheets.Item[1];
            List<string> ColumnsNames = GetColumnsNames(connectionString, table);
            int Row = 2;
            for (int i = 0; i != ColumnsNames.Count; i++)
            {
                worksheet.Cells[1, i + 1].Value = ColumnsNames[i];
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandString = "SELECT * FROM " + table;
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = commandString;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int Column = 0; Column != ColumnsNames.Count; Column++)
                            {
                                worksheet.Cells[Row, Column + 1] = reader.GetValue(Column);
                            }
                            Row++;
                        }
                    }
                }
                connection.Close();
            }
            workbook.SaveAs(saveAs);
            app.Quit();
        }
