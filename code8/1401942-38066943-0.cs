    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                Label lbl = (Label)e.Row.FindControl("lbl_Company");
                lbl.ToolTip = //Your tooltip;
            }
        }
