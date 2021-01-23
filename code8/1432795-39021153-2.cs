    public void AddSQLTableParm<T>(string parmName, 
            IEnumerable<T> values, 
            string typeName = "dbo.keyIds")  // <== here put SQL Server UDT Type neame
        {
            var parm = new SqlParameter(parmName, 
                              DbParamList.CreateDataTable(values))
            {
                SqlDbType = SqlDbType.Structured,
                TypeName = typeName
            };
            Add(parmName, parm);
        }
