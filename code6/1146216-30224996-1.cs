    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count > 1)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                Button Button3 = (Button)row.FindControl("Button3");
                Button3.Visible = true;
            }
        }
    }
