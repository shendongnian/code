    private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
    {
        if ( e.Index == tabControl1.SelectedIndex)
            e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
        else
            e.Graphics.FillRectangle(SystemBrushes.Control, e.Bounds);
          
        TabPage tp = tabControl1.TabPages[e.Index];
        Point pt = new Point(e.Bounds.X + 2, e.Bounds.Y + 4);
        e.Graphics.DrawString(tp.Text, tabControl1.Font, SystemBrushes.ControlText, pt);
        e.DrawFocusRectangle();
    }
