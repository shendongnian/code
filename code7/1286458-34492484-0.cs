        protected void Page_Load(object sender, EventArgs e)
                {
                    SqlConnection con = Connection.DBconnection();
                    if (!IsPostBack)
                    {
                        SqlCommand com = new SqlCommand("sp_studentresultentry", con);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@id_student", textstudentid.Text.Trim());
                        com.Parameters.AddWithValue("@id",Request.QueryString["id"]);                
                        SqlDataAdapter adp = new SqlDataAdapter(com);
                        DataSet ds = new DataSet();
                        adp.Fill(ds);     
                        if(adp.Fill(ds)==0)
                        {
                          lblNoresult.Text = "Marks didn't updated";
                        }
                        else
                        {           
                          lbltamil.Text = ds.Tables[0].Rows[0]["Tamil"].ToString();
                          lblenglish.Text = ds.Tables[0].Rows[0]["English"].ToString();
                          lblmaths.Text = ds.Tables[0].Rows[0]["Maths"].ToString();
                          lblscience.Text = ds.Tables[0].Rows[0]["Science"].ToString();
                          lblsocialscience.Text = ds.Tables[0].Rows[0]["SocialScience"].ToString();  
                        }          
                    }
                }
