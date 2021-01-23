    public static void insertToDB(List<YourModel> list)
        {
            DataTable table = new DataTable("table");
            DataColumn colA = new DataColumn("Column_A", Type.GetType("System.String"));
            table.Columns.Add(colA);
            DataColumn colB = new DataColumn("Column_B", Type.GetType("System.DateTime"));
            table.Columns.Add(colB);
            DataColumn colC = new DataColumn("Column_C", Type.GetType("System.TimeSpan"));
            table.Columns.Add(colC);
            DataColumn colD = new DataColumn("Column_D", Type.GetType("System.Int32"));
            table.Columns.Add(colD);
            foreach (var item in list)
            {
                DataRow newRow = table.NewRow();
                newRow["Column_A"] = item.colA == null ? DBNull.Value : (object)item.Celda_Destino;
                newRow["Column_B"] = item.colB == null ? DBNull.Value : (object)item.Celda_Origen; ;
                newRow["Column_C"] = item.colC == null ? DBNull.Value : (object)item.Celda_Destino;
                newRow["Column_D"] = item.colD;
                table.Rows.Add(newRow);
            }
            
            using (SqlConnection conn = new SqlConnection("YOUR CONNECTION STRING"))
            {
                conn.Open();
                using (SqlBulkCopy s = new SqlBulkCopy(conn))
                {
                    s.DestinationTableName = table.TableName;
                    foreach (DataColumn dc in table.Columns)
                    {
                        s.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);
                    }
                }
            }
        }
