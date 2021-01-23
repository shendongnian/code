    void theBoxCell_DrawItem(object sender, DrawItemEventArgs e)
    {
        if (e.Index < 0)
        {
           // drawstuff 2: draw the undropped top portion
        }
        else
        {
           if ((e.State & DrawItemState.Selected) != DrawItemState.None
           {
              // drawstuff 3:  draw a selected item
           }
           else
           {
              // drawstuff 4:  draw an unselected item   
           }
        }
     }
