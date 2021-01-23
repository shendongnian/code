    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkTest = (CheckBox)sender;
        GridViewRow grdRow = (GridViewRow)chkTest.NamingContainer;
    
        int count = 0;
    
        foreach (GridViewRow row in GridView1.Rows)
        {
           CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                
           if (chk.Checked)
           {
             count++;
           }
        }
    
        if(count==5)
        {
            btnUpdate.Enabled = true;
            btnUpdate.CssClass = "enabledImageButton";
        }
        else
        {
            btnUpdate.Enabled = false;
            btnUpdate.CssClass = "disabledImageButton";
        }
    }
