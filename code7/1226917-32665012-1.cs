    protected string GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                
                HyperLink hyp = (HyperLink)e.Row.FindControl("hyp");
                hyp.NavigateUrl = "www.google.com" + hyp.ClientID;
                // hyp.ClientID is your id of control
            }
        }
