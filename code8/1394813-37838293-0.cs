       public IEnumerable<T> FillDataRows<T>(String query, params SqlParameter[] sqlParams) {
            var properties = typeof(T).GetProperties().ToList();
            IList<T> result = new List<T>();
            var source = FillDataRows(query, sqlParams).ToList();
            var firstInSource = source.FirstOrDefault();
            if (firstInSource == null)
                return result;
            //remove properties not exist in source
            properties.RemoveAll(p => firstInSource.Table.Columns.Contains(p.Name) == false);
            foreach (var row in source) {
                var item = createItemFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }
            return result;
        }
        private T createItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) {
            T item = Activator.CreateInstance<T>();
            foreach (var property in properties) {
                if (row[property.Name] != System.DBNull.Value)
                    property.SetValue(item, row[property.Name], null);
            }
            return item;
        } 
        public void FillDataSet(DataSet ds, String dataTable, String query, params SqlParameter[] sqlParams) {
            using (var cn = new SqlConnection(this.connectionString)) {
                cn.Open();
                using (var cmd = cn.CreateCommand()) {
                    cmd.CommandTimeout = commandTimeout;
                    cmd.CommandText = query;
                    if (sqlParams != null && sqlParams.Length > 0)
                        cmd.Parameters.AddRange(sqlParams);
                    using (var adapter = new System.Data.SqlClient.SqlDataAdapter(cmd)) {
                        adapter.Fill(ds, dataTable);
                    }
                }
                cn.Close();
            }
        }
        public IEnumerable<DataRow> FillDataRows(String query, params SqlParameter[] sqlParams) {
            var ds = new DataSet();
            FillDataSet(ds, "Result", query, sqlParams);
            return ds.Tables["Result"].Rows.OfType<DataRow>();
        }
