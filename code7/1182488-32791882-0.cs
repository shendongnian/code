    public int StartMyJob( string connectionString )
    {
     using (var sqlConnection = new SqlConnection( connectionString ) )
     {
       sqlConnection.Open( );
       using (var execJob = sqlConnection.CreateCommand( ) )
       {
          execJob.CommandType = CommandType.StoredProcedure;
          execJob.CommandText = "msdb.dbo.sp_start_job";
          execJob.Parameters.AddWithValue("@job_name", "myjobname");
          execJob.Parameters.Add( "@results", SqlDbType.Int ).Direction = ParameterDirection.ReturnValue;      
          execJob.ExecuteNonQuery();
          return ( int ) sqlCommand.Parameters["results"].Value;
        }
      }
    }
