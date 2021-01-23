    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int no_job = Convert.ToInt32(e.Row.Cells[0].Text); // as your No of Job is at 0 place of Gridview
            int XDA = Convert.ToInt32(e.Row.Cells[1].Text); 
            Lable lblEpod = e.Row.FindControl("lblEpod") as Lable;
            lblEpod.Text = Convert.ToString(no_job - XDA);
        }
    }
