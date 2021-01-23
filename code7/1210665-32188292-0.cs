        public void Page_Load(object sender, EventArgs e)
        {
            Page PreviousPage = Page.PreviousPage;
            if (PreviousPage != null)
            {
                lblUserLogin.Text = ((TextBox)PreviousPage.FindControl("txtUser")).Text;
                lblAppLogin.Text = ((TextBox)PreviousPage.FindControl("txtAppNum")).Text;
            }
            {
                string _connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            }
            CheckRecord();
        }
        public void CheckRecord()
        {
            //get the connection
            using (SqlConnection conn = new SqlConnection(@"Data Source=ServerInfo"))
            {
                //write the sql statement to execute
                string sql = "select username FROM BLAA_users WHERE username = @username";
                //instantiate the command object to fire
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    //attatch the parameter to pass, if no parameter is in the sql no need to attatch
                    SqlParameter[] prms = new SqlParameter[1];
                    prms[0] = new SqlParameter("@username", SqlDbType.VarChar, 50);
                    prms[0].Value = lblUserLogin.Text.Trim();
                    cmd.Parameters.AddRange(prms);
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    conn.Close();
                    if (obj != null)
                    {
                        Response.Redirect("~/WebForm1.aspx");
                    }
                    else
                        Response.Redirect("http://www.google.com");
                }
            }
        }
