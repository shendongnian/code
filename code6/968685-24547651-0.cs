            protected void AgentSum_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label label = e.Row.FindControl("lblSumDate") as Label;
                    if (label != null)
                    {
                        var dataItem = e.Row.DataItem as dataitemtype; //change this to your domain object type
                        label.Text = dataItem.SumDate; // assign dynamically any value here
                    }
                }
            }
