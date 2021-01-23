    if(DateTime.Now >= dateaftersixmonth)
    {
     YourGridView.Columns[columnIndex].Visible = true; //columnIndex= column to show  after six month.
    }
    else 
    {
      YourGridView.Columns[columnIndex].Visible = false;
    }
 
