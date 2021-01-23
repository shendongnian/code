                    ConnectionManager ConMgr = Dts.Connections.Add("ADO.NET:SQL");
                    ConMgr.ConnectionString = "data source=database;initial catalog=zzzz_PRC;integrated security=true;persist security info=True;";
                    ConMgr.Name = "DBConn";
                    ConMgr.Description = "DBConn";
                    SqlConnection myADONETConnection = new SqlConnection();
                    myADONETConnection = (SqlConnection)
                    (Dts.Connections["DBConn"].AcquireConnection(Dts.Transaction) as SqlConnection);
