           protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["IsValidUser"] == null || Session["IsValidUser"].ToString() != "true")
                    Response.Redirect("Login.aspx", false);
                /// Setting the Body tag. 
                Site1 m = (Site1)Master;
                m.PageSection = "transactions";
                //AH setup the pagingQuery variable to cache where we are. 
                if (Session["pagingQuery"] == null) 
                {
                    Session.Add("pagingQuery", null);
                }
                if (!IsPostBack)
                {
                    Populate();
                }
                /////////////////////////////
                user = (User)Session["user"];
                
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
            }        
        }
