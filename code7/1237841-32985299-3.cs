	byte[] data = System.IO.File.ReadAllBytes(filePath);
	using(SqlCommand cm = new SqlCommand("SaveImage", connection, transaction))
	{
       cm.CommandType = CommandType.StoredProcedure;
       cm.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int,0, ParameterDirection.InputOutput, false, 10, 0, "Id", DataRowVersion.Current, (SqlInt32)instance.Id));
       cm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar,50, ParameterDirection.Input, false, 0, 0, "Title", DataRowVersion.Current, (SqlString)instance.Title));
       if (instance.Data.Length > 0)
       {
           cm.Parameters.Add(new SqlParameter("@Data", SqlDbType.VarBinary,instance.Data.Length, ParameterDirection.Input, false, 0, 0, "Data", DataRowVersion.Current, (SqlBinary)instance.Data));
       }
       else
       {
           cm.Parameters.Add(new SqlParameter("@Data", SqlDbType.VarBinary,0, ParameterDirection.Input, false, 0, 0, "Data", DataRowVersion.Current, DBNull.Value));                    
       }
       cm.ExecuteNonQuery();
	}
