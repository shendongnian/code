    private void TabControl1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
    {
	    Graphics g = e.Graphics;
	    Brush _TextBrush = default(Brush);
            // Get the item from the collection. 
	    TabPage _TabPage = TabControl1.TabPages(e.Index);
	    // Get the real bounds for the tab rectangle. 
	    Rectangle _TabBounds = TabControl1.GetTabRect(e.Index);
	    if ((e.State == DrawItemState.Selected)) 
            {
		    // Draw a different background color, and don't paint a focus rectangle.
		    _TextBrush = new SolidBrush(Color.Red);
		    g.FillRectangle(Brushes.Gray, e.Bounds);
	    } 
            else 
            {
		    _TextBrush = new System.Drawing.SolidBrush(e.ForeColor);
		    e.DrawBackground();
	    }
	    // Use our own font. 
	    Font _TabFont = new Font("Arial", 10.0, FontStyle.Bold, GraphicsUnit.Pixel);
	    // Draw string. Center the text. 
	    StringFormat _StringFlags = new StringFormat();
	    _StringFlags.Alignment = StringAlignment.Center;
	    _StringFlags.LineAlignment = StringAlignment.Center;
	    g.DrawString(_TabPage.Text, _TabFont, _TextBrush, _TabBounds, new StringFormat(_StringFlags));
    }
