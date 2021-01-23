    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if(e.Row.RowType == DataControlRowType.DataRow)
                {
                  LinkButton lbtn =  (LinkButton) e.Row.FindControl("LinkButton1");
                    lbtn.Text = "View";
                }
            }
    
            protected void LinkButton1_Click(object sender, EventArgs e)
            {
              LinkButton  lbtnClick = sender as LinkButton;
                lbtnClick.Text = "lnk1";
            }
