    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                Button name = (Button)GridView1.Rows[i].FindControl("lnkbtnInfo"); // find control from your button ID
                Label status= (Label)GridView1.Rows[i].FindControl ("lblStatus");
                if (status.Text == "Complete" || status.Text == "Rejected" || status.Text == "Cancelled" || 
                    status.Text == "Returned" || status.Text == "UserRejected")//refer to confirm and reject order
                {
                    name.Text = "View";
                }
               
                else // refer to pending order
                {
                    name.Text = "review";
                }
                
            }
        }
