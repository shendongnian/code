        public void dbQueueryExctr(string queuery)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            using (SqlConnection connectionx = new SqlConnection(CONNECTIONSTRING))
            {
                //YOU CALL OPEN HERE
                //DELETE THIS ONE!!!
                connectionx.Open();
                cmd.CommandText = queuery;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectionx;
                //AND OPEN HERE
                connectionx.Open();
                reader = cmd.ExecuteReader();
                //You do not need connectionx.Close() here
                //You have it within a using which will dispose the connection
                //upon exiting the using scope.
                connectionx.Close();
            }
