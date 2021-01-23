    public class myCombo : ComboBox
    {
        public myCombo()
        {
            DrawItem += new DrawItemEventHandler(DrawCustomMenuItem);
            DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            // or: DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        }
        protected  void DrawCustomMenuItem(object sender, DrawItemEventArgs e)
        {
            // do your drawstuff..e.g:
            e.DrawBackground();
            Graphics g = e.Graphics;
            Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
                            Brushes.LightSeaGreen : new SolidBrush(e.BackColor);
            g.FillRectangle(brush, e.Bounds);
            e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font,
                        new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }
       
    }
