    var listOfInvestor = new List<Investor>();
    
                string conn = "URI=file:" + Application.dataPath + "/db_01.s3db";
                using (var dbConnection = (IDbConnection)new SqlLiteConnection(conn))
                using (var dbcmd = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
    
                    string sqlQuery = "SELECT * " + " FROM investor; SELECT * " + " FROM Area;";
                    dbcmd.CommandText = sqlQuery;
                    IDataReader reader = dbcmd.ExecuteReader();
    
                    //Read first result set
                    while (reader.Read())
                    {
                        var investor = new Investor();
    
                        investor.iID = Convert.ToInt32(reader["i_id"]);
                        investor.iName = reader["i_name"].ToString();
                        investor.iDisplayName = reader["i_display_name"].ToString();
                        investor.iArea = reader["i_area"].ToString();
    
                        listOfInvestor.Add(investor);
                    }
    
    
                    //Repeat for your other result set
                    reader.NextResult();
                    while (reader.Read())
                    {
                        //Do areas stuff here
                    }
                }
