    foreach (GridViewRow row in GridView1.Rows)
    {
        CheckBox chk = (CheckBox)row.FindControl("chkSelect");
        if (chk.Checked) count++;
        if (count >= 5) 
        {
            btnUpdate.Enabled = true;
            btnUpdate.CssClass = "enabledImageButton";
            break; //Avoid hitting more rows than necessary
        }
    }
