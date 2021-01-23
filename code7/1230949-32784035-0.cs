    if(DateTime.Now >= dateaftersixmonth)
    {
     e.Row.Cells[columnIndex].Visible = true; //columnIndex= column to show  after six month.
    }
    else 
    {
      e.Row.Cells[columnIndex].Visible = false;
    }
 
