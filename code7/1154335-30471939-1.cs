    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        if (e.Index<0) return;
        //if the item state is selected them change the back color 
        if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            e = new DrawItemEventArgs(e.Graphics, 
                                      e.Font, 
                                      e.Bounds, 
                                      e.Index,
                                      e.State ^ DrawItemState.Selected,
                                      e.ForeColor, 
                                      selectedColor);
        // Draw the background of the ListBox control for each item.
        e.DrawBackground();
        // Draw the current item text
        e.Graphics.DrawString(listBox1.Items[e.Index].ToString(),e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
        // If the ListBox has focus, draw a focus rectangle around the selected item.
        e.DrawFocusRectangle();
    }
