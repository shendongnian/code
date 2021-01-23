                Conn = new SqlConnection(ConnStr);
                Conn.Open();
                myCommand = new SqlCommand();
                myCommand.CommandTimeout = 180000;
                myCommand.Connection = Conn;
                myCommand.CommandType = System.Data.CommandType.StoredProcedure;
