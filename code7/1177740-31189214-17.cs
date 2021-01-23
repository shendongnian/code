    void tp_MouseClick(object sender, MouseEventArgs e)
    {
        for (int t = 0; t < tabAreas.Count; t++)
        {
            if (tabAreas[t].IsVisible(e.Location) )
               { tabControl1.SelectedIndex = t; break;}
        }
        tp.Invalidate();
    }
    void tp_Paint(object sender, PaintEventArgs e)
    {
        StringFormat fmt = new StringFormat() 
          { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.Clear(Color.White);   // **
        float w = tp.Width / tabAreas.Count;
        for (int t = 0; t < tabAreas.Count; t++)
        {
            Rectangle rect = new Rectangle((int)(t * w ), 0, sz.Width, sz.Height);            
            bool selected = tabControl1.SelectedIndex == t ;
            Brush brush = selected ?  Brushes.DarkGoldenrod : Brushes.DarkGray;   // **
            e.Graphics.FillPath(brush, tabAreas[t]);
            e.Graphics.DrawString(tabControl1.TabPages[t].Text,
                    tabControl1.Font, Brushes.White, rect, fmt);
        }
    }
