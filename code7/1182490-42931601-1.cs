         private int CheckAgentJob(string connectionString, string jobName) {
            SqlConnection dbConnection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "msdb.dbo.sp_help_job";
            command.Parameters.AddWithValue("@job_name", jobName);
            command.Connection = dbConnection;
            using (dbConnection)
            {
                dbConnection.Open();      
                using (command){
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    int status = reader.GetInt32(21); // Row 19 = Date Row 20 = Time 21 = Last_run_outcome
                    reader.Close();
                    return status;
                }
            }
         }
    enum JobState { Failed = 0, Succeeded = 1, Retry = 2, Cancelled = 3, Unknown = 5};
