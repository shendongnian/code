            // `ConnectionString` specifies the Database
            SqlCeConnection connectionSql = new SqlCeConnection(ConnectionString);
            connectionSql.Open();
            // create new `DataAdapter` on `connectionSql` and Your `SelectQuery` text
            SqlCeDataAdapter dataAdapterSql = new SqlCeDataAdapter();
            dataAdapterSql.SelectCommand = new SqlCeCommand(SelectQuery, connectionSql);
            // create DataSet
            DataSet dataSet= new DataSet();
            // retrieve TableSchema
            DataTable[] _dataTablesSchema = dataAdapterSql.FillSchema(dataSet, SchemaType.Source);
            // there is only one Table in DataSet, so use 0-index
            DataTable  sourceDataTable = _dataTablesSchema[0];
            // use DataAdapter to Fill Dataset
            dataAdapterSql.Fill(sourceDataTable );
