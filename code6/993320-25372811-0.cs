    Public Object[] StoredProcCall(string storedProc, SqlDbParams sqlParams, type[] types)
    {
        var cmd = dbContext.Database.Connection.CreateCommand();
        cmd.CommandText = storedProc;
        cmd.CommandType = CommandType.StoredProcedure;
        if(parameters != null)
            cmd.Parameters.AddRange(sqlParams);
        var reader = cmd.ExecuteReader();
        try
        {
            dbContext.Database.Connection.Open();
            object[] mObj = new object[types.Count];
            for(int i = 0; i < types.Count; i++)
            {
                System.Reflection.MethodInfo method = typeof(AutoMapper.Mapper).GetMethod("DynamicMap", new Type[] { typeof(object)});
                var generic = method.MakeGenericMethod(types[i]);
                objected mappedData = generic.Invoke(this, new object[] { reader});
                mObj[i] = mappedData;
                if(!reader.NextResult())
                    break;
            }
            return mObj;
        }
        finally
        {
            dbContext.Database.Connection.Close();
        }
    }
