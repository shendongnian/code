    protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
       
       //Code Here to Disable button. I'd use a Foreach loop like this.
       foreach(GridViewRow gvr in GridView1.Rows)
       {
            Label label = ((Label)gvr.FindControl("label"));
            LinkButton edit = ((LinkButton)gvr.FindControl("edit"));
            if (label.Text == 1)
            {
               edit.Visible = false;
            }
       }       
    }
