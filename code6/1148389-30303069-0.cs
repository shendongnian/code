     if (!Page.IsPostBack)
            {
                if (Request.QueryString["edit"] != null)
                {
                    Panel1.Visible = true;
                    SqlConnection con2 = new SqlConnection();
                    con2.ConnectionString = GNews.Properties.Settings.Default.connectionstring;
                    DataTable dt3 = new DataTable();
                    con2.Open();
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand("select * from loadpost_view where Postid=" + Request.QueryString["edit"].ToString() + "", con2);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        title_txt.Text = myReader["Title"].ToString();
                        bodytxt.Text = myReader["Body"].ToString();
                    }
                    con2.Close();
                }
            }
