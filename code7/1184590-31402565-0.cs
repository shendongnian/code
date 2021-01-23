        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Authenticated"] != null)
            {
                bool authenticated = Convert.ToBoolean(Session["Authenticated"]);
                if (!authenticated)
                {
                    Response.Redirect("~/Home.aspx");
                }
            }
         }
 
