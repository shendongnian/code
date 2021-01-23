    protected void Page_Load(object sender, EventArgs e)
            {
                PullData();
            }
            public void PullData()
            {            
                string SQLRET = "SELECT RX_ID, ShopID, Primary_IP, ServiceType, Hardware FROM RouterHealthCheck";
    
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    
                conn.Open();
    
                SqlDataAdapter da = new SqlDataAdapter(SQLRET, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Columns.Add("Results", typeof(string));
    
    //iterate the rows and ping each IP. Additionaly you can also code to ignore repeating IP
    foreach (DataRow dr in ds.Tables[0].Rows)
                            {                            
    Ping ping = new Ping();
                    PingReply pingreply = ping.Send(dr["Primary_IP"].ToString());
    
                    if (pingreply.Status == IPStatus.Success)
                    {
                        dr["Results"] = string.Format("Success");
                    }
                    else
                    {
                        dr["Results"] = string.Format("Offline");
                    }
                            } 
    
    GridViewRouters.DataSource = dt;
                    GridViewRouters.DataBind();
    }
