    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkTest = (CheckBox)sender;
        GridViewRow grdRow = (GridViewRow)chkTest.NamingContainer;
    
        int count = 0;
        if (chkTest.Checked)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                count++;
    
                if (chk.Checked && count == 5)
                {
                    btnUpdate.Enabled = true;
                    btnUpdate.CssClass = "enabledImageButton";
                }
            }
        }
        if(count<5)
          btnUpdate.Enabled = false;
    }
