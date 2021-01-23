    SqlConnection addConn = new SqlConnection();
                addConn.ConnectionString = Properties.Settings.Default.yourDataBaseConnection;
                addConn.Open();
                SqlCommand addComm = new SqlCommand();
                addComm.Connection = addConn;
                addComm.CommandText = "sql command";
                addComm.ExecuteNonQuery();
