        protected void checkAll_CheckedChanged(object sender, EventArgs e)
            {
    CheckBox ChkBoxHeader = (CheckBox)GridView1.HeaderRow.FindControl("checkAll");
                    
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkbx_select");
        
                        if (ChkBoxRows!=null)
                        {
                            ChkBoxRows.Checked = true;
                        }
                    }
            }
