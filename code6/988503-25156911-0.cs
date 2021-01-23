    using (OleDbConnection connection = new OleDbConnection(connString))
                  {
                    connection.Open();
                    OleDbCommand cmnd = connection.CreateCommand();
                    cmnd.CommandText = queryString;
                    cmnd.Parameters.Add(new OleDbParameter("@patientID", patientID);
                    OleDbDataReader reader = cmnd.ExecuteReader();
                    while (reader.Read())
                    {....
