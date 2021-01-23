    var id = 0;
    
    using (var sqlDataReader = sqlCommand.ExecuteReader())
            {
                while (sqlDataReader.Read())
                {
                    id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("ColName"));
                }
            }
