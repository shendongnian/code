    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        if(e.Row.Cells[0].Text.Contains("0:00:00"))
           e.Row.Cells[0].Text = e.Row.Cells[0].Text.Replace("0:00:00", "");
      }
    }
