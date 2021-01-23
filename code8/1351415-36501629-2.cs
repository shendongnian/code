    DateTime tDate = Convert.ToDateTime(comboBox2.Text);
    ......
    string sql = @"SELECT 
                       T_CLOCK_SCORE,T_LANGUAGE_SCORE,T_RECALL_SCORE,
                       T_REGISTRATION_SCORE,T_ORIENTATION_SCORE,T_TIME 
                   FROM TEST_RESULTS 
                   WHERE P_ID=@id AND T_DATE=@date";
    using(SqlCommand command = new SqlCommand(sql, connection))
    { 
         command.Parameters.Add("@id", SqlDbType.Int).Value = pID;
         command.Parameters.Add("@date", SqlDbType.Date).Value = tdate;
         command.CommandTimeout = 3600;             
         using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
         { 
              while (reader.Read())
              ....
