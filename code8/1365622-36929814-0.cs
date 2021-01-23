    foreach (GridViewRow row in SiteGridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("process_flag") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string ID = row.Cells[columnID].Text;
