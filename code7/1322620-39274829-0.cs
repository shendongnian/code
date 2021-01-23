    protected void Page_Load(object sender, EventArgs e)
            { 
    if(!IsPostBack)
              {
                ddl.Items.Add(new ListItem("---",""));
                ddl.AppendDataBoundItems = true;
                String conStr = ConfigurationManager.ConnectionStrings["ConnectionString3"].ConnectionString;
                    string queryStr = "SELECT CAMPAIGN_ID, NAME FROM CAMPAIGN_INFO";
                    OracleConnection conn = new OracleConnection(conStr);
                    OracleCommand cmd = new OracleCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = queryStr;
                    cmd.Connection = conn;
    
                    try
                    {
                    conn.Open();
                        OracleDataReader rdr = cmd.ExecuteReader();
                      
    
                        while (rdr.Read())
                        {
                            ListItem li = new ListItem();
                            li.Value = rdr["CAMPAIGN_ID"].ToString();
                            li.Text = rdr["CAMPAIGN_ID"].ToString() +" - "+ rdr["NAME"].ToString();
    
                            ddl.Items.Add(li);
                        }
    
                    }
                catch (Exception)
                {
                    conn.Close();
                    conn.Dispose();
    
                }
    }
