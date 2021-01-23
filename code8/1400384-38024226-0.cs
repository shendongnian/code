            OracleConnection conn = null;
            try
            {
                conn = new OracleConnection(css.ConnectionString);
                conn.Open();
                return conn.GetSchema(Schema, RestrictionValues);
            }
            finally
            {
                if ((conn != null) && (conn.State != ConnectionState.Closed))
                    conn.Close();
            }
