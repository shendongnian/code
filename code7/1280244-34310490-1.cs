    private void panel1_Scroll(object sender, ScrollEventArgs e)
    {
      panel1_scrollcheck(e.NewValue);
    }
 
    private void panel1_MouseWheel(object sender, MouseEventArgs e)
    {
      panel1_scrollcheck(panel1.VerticalScroll.Value);
    }
    private void panel1_scrollcheck(int currPos)
    {
      if (currPos > panel1.VerticalScroll.Maximum - panel1.VerticalScroll.LargeChange)
        {
          //Put the logic here
        }
    }
