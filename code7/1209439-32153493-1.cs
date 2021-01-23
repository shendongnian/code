    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
       // Draw the background of the ListBox control for each item.
       e.DrawBackground();
   
       // Draw the current item text
       var currentItem = listBox1.Items[e.Index] as Audio;
       var outputStr = string.Format("{0}_{1}", currentItem.Artist, currentItem.Title);
       e.Graphics.DrawString(outputStr, e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
         
       // If the ListBox has focus, draw a focus rectangle around the selected item.
       e.DrawFocusRectangle();
    }
