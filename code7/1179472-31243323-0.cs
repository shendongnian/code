    protected void btnSendInvite_OnClick(object sender,EventArgs e)
    {
      Button btn=(Button)sender;
      GridViewRow row=(GridViewRow)btn.NamingContainer;
      string name=row.Cells[1].Text; // here you will get Name 
    }
