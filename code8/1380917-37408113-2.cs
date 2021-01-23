    var parameters = new SqlParamDefinition[]
    {
        new SqlParamDefinition("@Param1", SqlDbType.VarChar, "value1"),
        new SqlParamDefinition("@Param2", SqlDbType.VarChar, "value2"),
        new SqlParamDefinition("@Param3", SqlDbType.Int, 123),
    };
    var ds = ExecuteSelectProcedure("Strong procedure name", parameters);
