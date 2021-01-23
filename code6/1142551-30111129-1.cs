     protected void NamesGV_RowDataBound(object sender, GridViewRowEventArgs e) 
     {
        if (e.Row.RowType == DataControlRowType.Header) 
        {
            for (int i = 0; i < e.Row.Cells.Count; i++) 
            {
                e.Row.Cells[i].BackColor = System.Drawing.Color.Beige;
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
             //Get reference to the button you want to hide/show
             LinkButton delButton = CType(e.Row.Cells(2).FindControl("lbYourLinkButtonId"), LinkButton);
             
             //check your data for value
             bool visible = (bool)DoACheckForAValue(NamesGV.DataKeys(e.Row.RowIndex).Value);
             delButton.Visible = visible;
        }
    }
