    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton sendKwm =  (ImageButton) e.Row.FindControl("Sendkwm ");
            Label lblKwm = (Label) e.Row.FindControl("kwm");
            lblKwm.Text = Request.QueryString["kwm"]; 
        }
    }
