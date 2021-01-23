     int grandTotal = 0;
     protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int value = Convert.ToInt32(e.Row.Cells[2].Text);
                int value2 = Convert.ToInt32(e.Row.Cells[3].Text);
                int total = value * value2;
                grandTotal += total;
                e.Row.Cells[4].Text = Convert.ToString(total);
                lblgrandTota.Text = GrandTotal.ToString();
            }
        }
