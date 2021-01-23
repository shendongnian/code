        protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                Label lb =e.Row.FindControl("lbltxt") as Label;
                if (lb.Text.Length > 15)//any length u want
                {
                    DataRow drv = ((DataRowView)e.Row.DataItem).Row;
                    int tempID = Convert.ToInt32(drv["id"].ToString());
                   
                    HyperLink hp = new HyperLink();
                    hp.Text = "read more";
                    hp.NavigateUrl = "~/mydetails.aspx?id=" + tempID;
                   e.Row.Cells[1].Controls.Add(hp);
                  
                }
            }
        }
