    protected void txtQuantity_TextChanged(object sender, EventArgs e)
    {
         TextBox txtQuantity = (TextBox)sender;
         GridViewRow gridViewRow = (GridViewRow)txtQuantity.NamingContainer;
         DropDownList ddlProduct = (DropDownList)gridViewRow.FindControl("ddlProduct");
         Label lblGrossQuantity = (Label)gridViewRow.FindControl("lblGrossQuantity");
         TextBox txtUnit = (TextBox)gridViewRow.FindControl("txtUnit");
         //gridViewRow.Cells[3].FindControl("txtUnit").Focus();
         Session["event_control"] = ((TextBox)gridViewRow.FindControl("txtUnit"));
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        try
        {
            if (Session["event_control"] != null)
            { 
                TextBox control = (TextBox) Session["event_control"];
                control.Focus(); 
            }
        }
        catch (InvalidCastException inEx)
        {
        }        
    } 
