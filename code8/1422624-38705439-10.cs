            const string strcon = "whatevs";
            using (MySqlConnection con = new MySqlConnection(strcon))
            {
                const string sql = "login";
                MySqlCommand com = new MySqlCommand(sql, con);
                com.CommandType = CommandType.StoredProcedure;
                var stuffParam = new MySqlParameter("@stuff", stuffValue);
                var passParam = new MySqlParameter("@pass", passValue);
                var param3Param = new MySqlParameter();
                param3Param.ParameterName = "param3";
                param3Param.DbType = DbType.Int32;
                param3Param.Direction = ParameterDirection.Output;
                com.Parameters.Add(stuffParam);
                com.Parameters.Add(passParam);
                com.Parameters.Add(param3Param);
                try
                {
                    var scalarResult = com.ExecuteScalar();
                    // because you used select @param3 in your sp.
                    int value;
                    if (int.TryParse($"{scalarResult}", out value))
                    {
                        //do something with value
                    }
                    //// because you used select @param3 in your sp.
                    //var readerResult = com.ExecuteReader();
                    //if (readerResult.Read())
                    //{
                    //    // 
                    //    value = readerResult.GetInt32(0);
                    //}
                    int param3Returned;
                    if(int.TryParse($"{param3Param.Value}", out param3Returned))
                    {
                        // do something with param3Returned
                    }
                }
                catch (Exception ex)
                {
                    // do something with ex
                }
            }
