    var schema = yourSqlCommand.ExecuteReader().GetSchemaTable();
    var Columns = schema.Rows.Cast<DataRow>().Select(row=>new DbColumnInfo
        {
            Name = row.Field<string>("ColumnName"),
            SqlDataType = GetSqlTypeFromSchemaRow(row) //extract information about SQL type which I need, using schemaRow.Field<string>("DataTypeName"), schemaRow.Field<short>("NumericPrecision"), schemaRow.Field<short>("NumericScale") etc.
        }).ToArray();
