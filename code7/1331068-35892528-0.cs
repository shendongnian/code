            var entityConnection = MyDbContext.Database.Connection.ConnectionString;
            DbConnection conn = entityConnection;
            ConnectionState initialState = conn.State;
            if (initialState != ConnectionState.Open)
                conn.Open();
            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "sp_helptext";
                cmd.Parameters.Add(new SqlParameter("@name", "dbo.AProcedure"));
                cmd.CommandType = CommandType.StoredProcedure;
                var result = cmd.ExecuteScalar();
            }
