            SqlConnection objConnection = new SqlConnection(string.Concat(connectionString));
            try
            {
               objConnection.Open();
            }
            catch {}
            if (objConnection != null && objConnection.State == ConnectionState.Open)
            {
                try
                {
                   objConnection.Close();
                }
                catch {}
                return true;
            }
            else if (objConnection != null && objConnection.State == ConnectionState.Closed)
            {
                try
                {
                   objConnection.Close();
                }
                catch {}
                return false;
            }
