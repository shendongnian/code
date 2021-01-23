            int i = 0;
            const string connectionString = "Data Source=CH-PC;Initial Catalog=Importar;Integrated Security=True";
            var dbConn = new SqlConnection(connectionString);
            var sr = new StreamReader(@"C:\sourcefiles\test.txt");
            string line = sr.ReadLine();
            string[] strArray = line.Split(',');
            var dt = new DataTable();
            for (int index = 0; index < strArray.Length; index++)
                dt.Columns.Add(new DataColumn());
            do
            {
                DataRow row = dt.NewRow();
                string[] itemArray = line.Split(',');
                row.ItemArray = itemArray;
                dt.Rows.Add(row);
                i = i + 1;
                line = sr.ReadLine();
            } while (!string.IsNullOrEmpty(line));
            var bc = new SqlBulkCopy(dbConn, SqlBulkCopyOptions.TableLock, null)
            {
                DestinationTableName = "TestData",
                BatchSize = dt.Rows.Count
            };
            dbConn.Open();
            bc.WriteToServer(dt);
            dbConn.Close();
            bc.Close();
