    protected void chkbox_CheckedChanged(object sender, EventArgs e)
    {
       CheckBox chkbox= sender as CheckBox;
       GridViewRow currentRow = chkbox.NamingContainer as GridViewRow;
       RequiredFieldValidator rfv = grdCustomer.Rows[currentRow.RowIndex]
                                          .FindControl("ValReqED") as RequiredFieldValidator;
       if (chkCustomer.Checked)
       {
          rfv .Enabled = true;
       }
    }
