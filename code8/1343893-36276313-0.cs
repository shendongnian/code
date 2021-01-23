    static void Main(string[] args)
            {
                string param = "VINET";//your param here
                string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                using(SqlConnection  conn = new SqlConnection(conStr))
                {
                    conn.Open();
                    //modify your command on below line
                    SqlCommand cmd = new SqlCommand("select count(OrderId) from Orders where CustomerID='" + param + "'");
                    cmd.Connection = conn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    conn.Close();
                    if(ds.Tables[0].Rows.Count > 0)
                    {
                        //do other staff
                    }
                }
            }   
