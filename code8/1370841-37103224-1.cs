    if (!IsPostBack)
            {
                int row = 0;
                if (Request.QueryString["itemID"] != null)
                {    
                    row = int.Parse(Request.QueryString["itemID"]);
                }
                else
                {
                    // here even if you make redirect the code continue to run
                    // and you do not know whats going on then... a call to db and a redirect.
                    Response.Redirect("itemedit.aspx");
                    // so here add a return;
                    return;
                }    
            }
