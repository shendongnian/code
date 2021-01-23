    strSQL = "Select [Name], AVG([Total Usage]) As AvrUsage FROM [YourTableName] GROUP BY [Name]";
                   // get data table with two columns: Name and AvgUsage
                    using (SqlConnection _connSql = new SqlConnection(connString))
                    {
                        using (SqlCommand _commandSql = new (SqlCommand())
                        {
                            _commandSql.CommandType = CommandType.Text;
                            _commandSql.Connection = _connSql;
                            _commandSql.CommandText = strSQL;
                            _connSql.Open();
        
                            using (SqlDataReader _drSql = _commandSql.ExecuteReader())
                            {
                                DataTable _dt = new DataTable();
                                _dt.Load(_drSql);
                                return _dt;
                            }
                        }
                    }
                }
                catch (Exception ex) {
                    throw; 
                }
