    protected void chkRow_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ck1 = (CheckBox)sender;
    
        GridViewRow grow =(GridViewRow)ck1.NamingContainer;
        DropDownList ddlR = (DropDownList)grow.FindControl("ddlCP1");
    
        if (ck1.Checked == true)
            ddlR.Enabled = true;
        else
            ddlR.Enabled = false;
    }
