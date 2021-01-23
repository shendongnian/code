    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["Alert"]))
                    {
                        if (Request.QueryString["Alert"] == "y" && Request.UrlReferrer.LocalPath == "/pqr.aspx") // if the root is same
                        {
                          //Here on redirection from Pqr.aspx i will display Javascript alert that your "Your data save"
                        }
                    }
                    else
                    {
                            //Dont do anything
                     }
                }
    
            }
