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
             // a dropdownlist may initially have no item selected, so skip the highlighting:
            if (e.Index >= 0) 
            {  
               Graphics g = e.Graphics;
               Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
                               new SolidBrush(BackColor) : new SolidBrush(e.BackColor);
               Brush tBrush = new SolidBrush(e.ForeColor);
               g.FillRectangle(brush, e.Bounds);
               e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font,
                        tBrush, e.Bounds, StringFormat.GenericDefault);
               brush.Dispose();
               tBrush.Dispose();
            }
            e.DrawFocusRectangle();
        }
       
    }
