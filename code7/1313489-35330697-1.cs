     protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chk = (CheckBox)e.Row.FindControl("chkBox");
                if (chk.Checked==true)
                {
                    chk.Enabled = false;
                }
                else
                {
                    chk.Enabled = true;
                }
            }
        }
