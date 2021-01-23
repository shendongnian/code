    protected void gvMaint_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowState == DataControlRowState.Edit)
        {
            TextBox txtFreqMiles = (TextBox)e.Row.FindControl("txtFreqMiles");
    
            // At this point, you can change the value as normal
            txtFreqMiles.Text = "some new text";
        }
    }
