    protected void LinkButton1_Click(object sender, EventArgs e)
    {
      LinkButton lnkBtn = (LinkButton)sender;
      GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;
      DropDownList ddl= (DropDownList)row.FindControl("DropDownList1");
      TextBox1.Text = ddl.SelectedValue.ToString();
    }
   
