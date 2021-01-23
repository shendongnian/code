    protected void chkbx_select_CheckedChanged(object sender, EventArgs e)
        {
    CheckBox ChkBoxHeader = (CheckBox)GridView1.HeaderRow.FindControl("checkAll");
                bool isAllChecked = false;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkbx_select");
    
                    if (!(ChkBoxHeader.Checked && ChkBoxRows.Enabled))
                    {
                        isAllChecked = true;
                    }
                }
    
                if (!isAllChecked)
                {
                    ChkBoxHeader.Checked = true;
                }
    }
