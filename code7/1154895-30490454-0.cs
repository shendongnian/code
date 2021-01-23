    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblEndDate = (Label)e.Row.FindControl("lblStudyEndDate");
                TextBox tbSomeTB = e.Row.FindControl("tbSomeTB") as TextBox;
                
                DateTime EndDate = DateTime.Parse(lblEndDate.Text);
                if (EndDate < DateTime.Today)
                {
                    e.Row.BackColor = System.Drawing.Color.DarkGray;
                    tbSomeTB.Enabled = false;
                }
            }
        }
