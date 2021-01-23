        if (e.Row.RowType == DataControlRowType.Header)
        {
              e.Row.Cells[1].ColumnSpan = 2;
              e.Row.Cells[2].Visible = false;
              e.Row.Cells[1].Text = "Optimized";
        }
