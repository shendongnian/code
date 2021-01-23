    public class myCombo : ComboBox
    {
        // expose properties as needed
        public Color BackColor { get; set; }
        // constructor
        public myCombo()
        {
            DrawItem += new DrawItemEventHandler(DrawCustomMenuItem);
            DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            BackColor = Color.LightSeaGreen;
        }
        protected  void DrawCustomMenuItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;
            Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
                            new SolidBrush(BackColor) : new SolidBrush(e.BackColor);
            g.FillRectangle(brush, e.Bounds);
            e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font,
                        new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
            brush.Dispose();
        }
       
    }
