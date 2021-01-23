    if(e.Row.RowType == DataControlRowType.DataRow)
    {
      if(e.Row.Cells[2].Text = "some string")
      {
        Button delete = (Button)e.Row.FindControl("control id to hide");
        delete.Visisble = false;
      }
    }
