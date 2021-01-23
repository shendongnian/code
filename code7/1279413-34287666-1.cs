    if (e.NewValue == panel1.VerticalScroll.Maximum - panel1.VerticalScroll.LargeChange + 1)
    {
    if(e.NewValue!=e.OldValue)// checking when the scrollbar is at bottom and user clicks/scrolls the scrollbar
      
      {
         MessageBox.Show("Test"); //Or some operation
      }
    }
