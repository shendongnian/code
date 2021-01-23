            using (DealerContext objectContext = new DealerContext())
            {
                string connString = objectContext.Database.Connection.ConnectionString;
                using (var conn = new OracleConnection(connString))
                {
                    using (var cmd = new OracleCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "select MY_SCHEMA.GET_NEXT_DEALER_KY FROM DUAL";
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection.Open();
                        try
                        {
                            var kyo = (decimal)cmd.ExecuteScalar();
                            return Decimal.ToInt32(kyo);
                        }
                        finally
                        {
                            cmd.Connection.Close();
                        }
                    }            
                }
           }
