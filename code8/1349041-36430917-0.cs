    private void gvValues_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Make sure current row is a data row (not header, footer, etc.)
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Get checkbox control
           var chkProductonline= e.Row.FindControl("chkProductonline") as CheckBox;
           // Get data item (recommend adding some error checking here to make sure it's really a Product)
           var product = e.Row.DataItem as Product
           // Set checkbox checked attribute
           chkProductonline.Checked = product.on;
        }
    }
