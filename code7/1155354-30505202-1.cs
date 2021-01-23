    foreach(GridViewRow gridRow in myGridview.Rows)
    {
        for(int i = 0; i < myGridview.Columns.Count, i++)
        {
            if(gridRow.Cells[i].Value=="M")
            {
              //Perform action
            }
        }
    }
