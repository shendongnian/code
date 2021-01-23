            protected void AgentSum_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                            var dataItem = e.Row.DataItem as DataRow; //change this to your domain object type
            foreach (Control RowControl in e.Row.Controls)
            {
                if (RowControl as Label != null) (RowControl as Label).Text = dataItem[(RowControl as Label).Text].ToString();
            }
            }
