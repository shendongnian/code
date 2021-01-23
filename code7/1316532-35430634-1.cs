    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label schedule = (Label)e.Row.FindControl("schedule");
                LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
                if (schedule.Text == string.Empty)
                {
                    LinkButton1.Enabled = false;
                }
                else
                {
                    LinkButton1.Enabled = true;
                }
            }
        }
