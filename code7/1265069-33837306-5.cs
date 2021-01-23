    public static class ExcelExtensions
    {
        private static string GetExcelConnectionString(string path)
        {
            string connectionString = string.Empty;
            if (path.EndsWith(".xls"))
            {
                connectionString = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;
                Data Source={0};
                Extended Properties=""Excel 8.0;HDR=YES;IMEX=1""", path);
            }
            else if (path.EndsWith(".xlsx"))
            {
                connectionString = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;
                Data Source={0};
                Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1""", path);
            }
            return connectionString;
        }
        public static string SerializeJsonToString(string path, string workSheetName, JsonSerializerSettings settings = null)
        {
            using (var writer = new StringWriter())
            {
                SerializeJsonToStream(path, workSheetName, writer, settings);
                return writer.ToString();
            }
        }
        public static void SerializeJsonToStream(string path, string workSheetName, Stream stream, JsonSerializerSettings settings = null)
        {
            using (var writer = new StreamWriter(stream))
                SerializeJsonToStream(path, workSheetName, writer, settings);
        }
        public static void SerializeJsonToStream(string path, string workSheetName, TextWriter writer, JsonSerializerSettings settings = null)
        {
            settings = settings ?? new JsonSerializerSettings();
            var converter = new DataReaderConverter();
            settings.Converters.Add(converter);
            try
            {
                string connectionString = GetExcelConnectionString(path);
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
                using (DbDataAdapter adapter = factory.CreateDataAdapter())
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    using (DbCommand selectCommand = factory.CreateCommand())
                    {
                        selectCommand.CommandText = String.Format("SELECT * FROM [{0}]", workSheetName);
                        selectCommand.Connection = conn;
                        adapter.SelectCommand = selectCommand;
                        using (var reader = selectCommand.ExecuteReader())
                        {
                            JsonExtensions.SerializeToStream(reader, writer, settings);
                        }
                    }
                }
            }
            finally
            {
                settings.Converters.Remove(converter);
            }
        }
    }
