     try
            {
                var oraCntStr = new OracleConnectionStringBuilder
                {
                    DataSource =
                        "<something to connect to your database>",
                    UserID = "<login>",
                    Password = "<password>"
                };
                using (OracleConnection oraCntgv = new OracleConnection(oraCntStr.ToString()))
                {
                    oraCntgv.Open();
                    OracleCommand oraCmd = oraCntgv.CreateCommand();
                    oraCmd.Parameters.Add(new OracleParameter("<parameter's name>", OracleDbType.Varchar2));
                    oraCmd.Parameters["<parameter's name>"].Value = Unum;
                    oraCmd.CommandText = @"<Select sentence with your <:parameter's name>>";
                    OracleDataReader oraReader = oraCmd.ExecuteReader();
                    if (oraReader.HasRows)
                    {
                        GridView1.DataSource = oraReader;
                        GridView1.DataBind();
                    }
                    oraCmd.Dispose();
                    oraReader.Close();
                }
                  
            }
             catch (Exception err)
            {
                tbxTFStr.Text = "Something goes wrong: " + err.Message;
            }
