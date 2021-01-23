    TextBox txtName = row.FindControl("textbox1") as TextBox;
    if(txtEmail != null)
    {
    	EditT.Tables[0].Rows[RowIndex]["Name"] = txtName.Text;
    }
    
    TextBox txtEmail = row.FindControl("textbox2") as TextBox;
    if(txtEmail != null)
    {
    	EditT.Tables[0].Rows[RowIndex]["Email"] = txtEmail.Text;
    }
