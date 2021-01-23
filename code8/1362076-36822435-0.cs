            SqlConnection objConnection = new SqlConnection(string.Concat(connectionString));
            if (objConnection != null && objConnection.State == ConnectionState.Open)
            {
                return true;
            }
            else if (objConnection != null && objConnection.State == ConnectionState.Closed)
            {
                return false;
            }
