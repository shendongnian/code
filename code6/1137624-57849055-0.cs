        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int id = Convert.ToInt32(e.Row.Cells[1].Text);
            if (id > 0)
            {
                e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                e.Row.Cells[1].Text = Math.Abs(id).ToString();
                e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
            }
        }
