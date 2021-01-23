    string connStr = "User Id=myuser;Password=mypass;Data Source=myinstance;";
                    using (OracleConnection con = new OracleConnection(connStr))
                    {
                        string s = @"BEGIN
                        select 1 into :TESTID from dual where 1=0;
                        EXCEPTION
                        when no_data_found then
                        select -1 into :TESTID from dual; 
                        END;";
    
                        using (OracleCommand cmd = new OracleCommand(s, con))
                        {
                            con.Open();
                            Console.WriteLine("Running statement");
    
                            OracleParameter prm = new OracleParameter();
                            cmd.Parameters.Clear();
                            cmd.BindByName = true;
    
                            //prm = new OracleParameter("TESTID", OracleDbType.Int32, ParameterDirection.InputOutput); prm.Value = 0; cmd.Parameters.Add(prm);
                            prm = new OracleParameter();
                            prm.ParameterName = "TESTID";
                            prm.DbType = DbType.Int32; // don't use OracleDbType, will return decimal in some cases, not int
                            prm.Direction = ParameterDirection.InputOutput;
                            prm.Value = 0;
                            cmd.Parameters.Add(prm);
                            
                            cmd.ExecuteNonQuery();
    
                            // may have cast/conversion issues here if using OracleDbType
                            int id = Convert.ToInt32(cmd.Parameters["TESTID"].Value);
    
                            Console.WriteLine("ID is: " + id);
    
                            con.Close();
                        }
                    }
