    protected void Page_Load(object sender, EventArgs e){
	    if (Page.RouteData.Values["name"] == null)
		    Response.Redirect("~/Home");
	    else{
		    string name = Page.RouteData.Values["name"].ToString();
		    if (!IsPostBack)
			    RetrieveArticleByItsName(name);
	    }
    }
    protected void RetrieveArticleByItsName(string article){
	    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["YourConnectionName"].ConnectionString;
	    SqlCommand cmd = new SqlCommand("select TOP 1 * from Articles where lower(name) = lower(@name)", con);
	    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = article;
	
	    try{
		    con.Open();
		    SqlDataReader sdr = cmd.ExecuteReader();
		    sdr.Read();
		    imgImage.ImageUrl = "your_folder/" + sdr["image"].ToString();
		    lblDetails.Text = sdr["info"].ToString();
	    }
	    catch(Exception ex){
		    //work with exceptions
            Response.Write("<script language='javascript'>alert('" + ex.Message.ToString() + "');</script"); // Get alert with exception
	    }
	    finally{
		    con.Close();
	    }
    }
