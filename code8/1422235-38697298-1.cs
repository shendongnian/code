     protected void Page_Load(object sender, EventArgs e)
            {
             if(!IsPostBack){
                try
                {
                    if (string.IsNullOrEmpty(tbSearch.Text))
                    {
                        HtmlGenericControl Emptydiv=(HtmlGenericControl)gvAcheologyMonuments.Controls[0].Controls[0].FindControl("hideInPageLoad") ;
                        Emptydiv.Style.Add("Display", "none");
                    }
            }
          }
        }
