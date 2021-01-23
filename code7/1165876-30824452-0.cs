       // colors to use
       private Color[] TColors = {Color.Salmon, Color.White, Color.LightBlue};
       private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
       {
           // get ref to this page
           TabPage tp = ((TabControl)sender).TabPages[e.Index];
           
           using (Brush br = new SolidBrush(TColors[e.Index]))
           {
               Rectangle rect = e.Bounds;
               e.Graphics.FillRectangle(br, e.Bounds);
               rect.Offset(1, 1);
               TextRenderer.DrawText(e.Graphics, tp.Text, 
                      tp.Font, rect, tp.ForeColor);
               // draw the border
               rect = e.Bounds;
               rect.Offset(0, 1);
               rect.Inflate(0, -1);
               // ControlDark looks right for the border
               using (Pen p = new Pen(SystemColors.ControlDark))
               {
                   e.Graphics.DrawRectangle(p, rect);
               }
               if (e.State == DrawItemState.Selected) e.DrawFocusRectangle();
            }
       }
