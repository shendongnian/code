    public String executeScalarCommandString(String conString, OdbcCommand command)
            {
                //starting stopwatch here
                String result = "";
                // remember we have already a connection which already open
                // so we dont have to create new connection
    /* we dont need this :: using (OdbcConnection connection = new OdbcConnection(conString))*/
                {
                    try
                    {
     // i'll assume the connection already on command object
                        //command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        //connection.Open();
                        object obj = command.ExecuteScalar();
                        if (obj != null && DBNull.Value != obj)
                            result = obj.ToString();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                    }
                    //stop and restart stopwatch here. Avg elapsed time: 10 ms
                }
                //stop stopwatch here. Avg elapsed time: 76 ms
                return result;
            }
