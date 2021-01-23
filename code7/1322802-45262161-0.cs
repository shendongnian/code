      using (var command = this.DbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT ... WHERE ...> @p1)";
                command.CommandType = CommandType.Text;
                var parameter = new SqlParameter("@p1",...);
                
                this.DbContext.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                       .... // Map to your entity
                    }
                }
            }
