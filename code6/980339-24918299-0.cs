     List<SqlParameter> prm = new List<SqlParameter>()
     {
         new SqlParameter("@variable1", SqlDbType.Int) {Value = myValue1},
         new SqlParameter("@variable2", SqlDbType.NVarChar) {Value = myValue2},
         new SqlParameter("@variable3", SqlDbType.DateTime) {Value = myValue3},
     };
     cmd.Parameters.AddRange(prm.ToArray());
