    protected void OnSelectedIndexChangedMS(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            Control ctl = row.FindControl("ButtonUp");
            ctl.Visible = (row.RowState & DataControlRowState.Selected) != 0;
        }
    }
