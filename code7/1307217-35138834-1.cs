    ADODB.Recordset ExecuteProcedure(string procedure, List<SqlParameter> parameters, List<Alias> alias)
    {
        SqlCommand commando = new SqlCommand(procedure, this.Connection);
        commando.CommandType = CommandType.StoredProcedure;
        commando.CommandTimeout = this.TimeOut;
        if (parameters != null)
        {
            foreach (SqlParameter param in parameters)
            { commando.Parameters.Add(param); }
        };
        SqlDataReader dr = commando.ExecuteReader();
        ADODB.Recordset result = new ADODB.Recordset();
        result.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
        
        //get table schema
        DataTable schema = dr.GetSchemaTable();
        foreach (var item in alias.OrderBy(o => o.ColumnIndex).ToList())
        {
            Type fieldType = dr.GetFieldType(dr.GetOrdinal(item.ColumnName));
            result.Fields.Append(item.Alias
                , TranslateType(fieldType)
                , Convert.ToInt32(schema.Rows[dr.GetOrdinal(item.ColumnName)]["ColumnSize"])
                , schema.Rows[dr.GetOrdinal(item.ColumnName)]["AllowDBNull"].ToString().ToLower().Equals("true") ? ADODB.FieldAttributeEnum.adFldIsNullable : ADODB.FieldAttributeEnum.adFldUnspecified
                , null);
        }
        result.Open(System.Reflection.Missing.Value, System.Reflection.Missing.Value
                , ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic, 0);
        while (dr.Read())
        {
            result.AddNew(System.Reflection.Missing.Value, System.Reflection.Missing.Value);
            foreach (var item in alias.OrderBy(o => o.ColumnIndex).ToList())
            {
                result.Fields[item.ColumnIndex - 1].Value = dr[item.ColumnName];
            }
        }
        dr.Close();
        return result;
    }
