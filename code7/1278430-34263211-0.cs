    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblIsActive = e.Row.FindControl("lblIsActive") as Label;
            if(lblIsActive.Text == "Y")
                lblIsActive.SkinID = "sknActive";
            else
                lblIsActive.SkinID = "sknInactive";
        }
    }
