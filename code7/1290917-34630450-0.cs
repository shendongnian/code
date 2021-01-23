     public class WipHub : Hub
        {
            public static System.Timers.Timer _Timer;
            public void startWip()
            {
                if (_Timer == null)
                {
                    _Timer = new System.Timers.Timer(2000);
                    _Timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
                    _Timer.Enabled = true;
                    _Timer.Interval = 1000;
                }
            }
            private void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
            {
                Clients.All.ReceiveWip(SendWip());
            }
    
    
            public string SendWip()
            {
                string param = "";
                int TML1 = 0; int TML2 = 0; int TMT1 = 0; int TMT2 = 0;
                int MLT1 = 0; int SNL1 = 0; int CAV1 = 0; int IBL1 = 0; int PAW1 = 0; int PLB1 = 0;
                int MLT2 = 0; int SNL2 = 0; int CAV2 = 0; int IBL2 = 0; int PAW2 = 0; int PLB2 = 0;
                int MLT3 = 0; int SNL3 = 0; int CAV3 = 0; int IBL3 = 0; int PAW3 = 0; int PLB3 = 0;
                int MLT4 = 0; int SNL4 = 0; int CAV4 = 0; int IBL4 = 0; int PAW4 = 0; int PLB4 = 0;
                int MLT5 = 0; int SNL5 = 0; int CAV5 = 0; int IBL5 = 0; int PAW5 = 0; int PLB5 = 0;
    
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    string query = "Select MLT1,MLT2,MLT3,MLT4,MLT5,SNL1,SNL2,SNL3,SNL4,SNL5,CAV1,CAV2,CAV3,CAV4,CAV5,IBL1,IBL2,IBL3,IBL4,IBL5,PAW1,PAW2,PAW3,PAW4,PAW5,PLB1,PLB2,PLB3,PLB4,PLB5,TML1,TML2,TMT1,TMT2 FROM WIP_Table Where ID=" + 1;
                    connection.Open();
    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Notification = null;
                        DataTable dt = new DataTable();
                        SqlDependency dependency = new SqlDependency(command);
    
                        dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                            SqlDependency.Start(connection.ConnectionString);
                        }
    
                        var reader = command.ExecuteReader();
                        dt.Load(reader);
                        if (dt.Rows.Count > 0)
                        {
                            MLT1 = int.Parse(dt.Rows[0]["MLT1"].ToString());
                            MLT2 = int.Parse(dt.Rows[0]["MLT2"].ToString());
                            MLT3 = int.Parse(dt.Rows[0]["MLT3"].ToString());
                            MLT4 = int.Parse(dt.Rows[0]["MLT4"].ToString());
                            MLT5 = int.Parse(dt.Rows[0]["MLT5"].ToString());
                            SNL1 = int.Parse(dt.Rows[0]["SNL1"].ToString());
                            SNL2 = int.Parse(dt.Rows[0]["SNL2"].ToString());
                            SNL3 = int.Parse(dt.Rows[0]["SNL3"].ToString());
                            SNL4 = int.Parse(dt.Rows[0]["SNL4"].ToString());
                            SNL5 = int.Parse(dt.Rows[0]["SNL5"].ToString());
                            CAV1 = int.Parse(dt.Rows[0]["CAV1"].ToString());
                            CAV2 = int.Parse(dt.Rows[0]["CAV2"].ToString());
                            CAV3 = int.Parse(dt.Rows[0]["CAV3"].ToString());
                            CAV4 = int.Parse(dt.Rows[0]["CAV4"].ToString());
                            CAV5 = int.Parse(dt.Rows[0]["CAV5"].ToString());
                            IBL1 = int.Parse(dt.Rows[0]["IBL1"].ToString());
                            IBL2 = int.Parse(dt.Rows[0]["IBL2"].ToString());
                            IBL3 = int.Parse(dt.Rows[0]["IBL3"].ToString());
                            IBL4 = int.Parse(dt.Rows[0]["IBL4"].ToString());
                            IBL5 = int.Parse(dt.Rows[0]["IBL5"].ToString());
                            PAW1 = int.Parse(dt.Rows[0]["PAW1"].ToString());
                            PAW2 = int.Parse(dt.Rows[0]["PAW2"].ToString());
                            PAW3 = int.Parse(dt.Rows[0]["PAW3"].ToString());
                            PAW4 = int.Parse(dt.Rows[0]["PAW4"].ToString());
                            PAW5 = int.Parse(dt.Rows[0]["PAW5"].ToString());
                            PLB1 = int.Parse(dt.Rows[0]["PLB1"].ToString());
                            PLB2 = int.Parse(dt.Rows[0]["PLB2"].ToString());
                            PLB3 = int.Parse(dt.Rows[0]["PLB3"].ToString());
                            PLB4 = int.Parse(dt.Rows[0]["PLB4"].ToString());
                            PLB5 = int.Parse(dt.Rows[0]["PLB5"].ToString());
                            TML1 = int.Parse(dt.Rows[0]["TML1"].ToString());
                            TML2 = int.Parse(dt.Rows[0]["TML2"].ToString());
                            TMT1 = int.Parse(dt.Rows[0]["TMT1"].ToString());
                            TMT2 = int.Parse(dt.Rows[0]["TMT2"].ToString());
    
                            param = MLT1 + ","
                                         + MLT2
                                         + ","
                                         + MLT3
                                         + ","
                                         + MLT4
                                         + ","
                                         + MLT5
                                         + ","
                                         + SNL1
                                         + ","
                                         + SNL2
                                         + ","
                                         + SNL3
                                         + ","
                                         + SNL4
                                         + ","
                                         + SNL5
                                         + ","
                                         + CAV1
                                         + ","
                                         + CAV2
                                         + ","
                                         + CAV3
                                         + ","
                                         + CAV4
                                         + ","
                                         + CAV5
                                         + ","
                                         + IBL1
                                         + ","
                                         + IBL2
                                         + ","
                                         + IBL3
                                         + ","
                                         + IBL4
                                         + ","
                                         + IBL5
                                        + ","
                                        + PAW1
                                        + ","
                                        + PAW2
                                        + ","
                                        + PAW3
                                        + ","
                                        + PAW4
                                        + ","
                                        + PAW5
                                        + ","
                                        + PLB1
                                        + ","
                                        + PLB2
                                        + ","
                                        + PLB3
                                        + ","
                                        + PLB4
                                        + ","
                                        + PLB5
                                        + ","
                                        + TML1
                                        + ","
                                        + TML2
                                        + ","
                                        + TMT1
                                        + ","
                                        + TMT2;
    
                        }
    
                    }
    
                }
                return param;
            }
        }
