        public class TopBorderLabel : Label
        {
               protected override void OnPaint(PaintEventArgs e)
               {
                 base.OnPaint(e);
                 ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                              Color.White, 0, ButtonBorderStyle.None,
                                              Color.Black, 2, ButtonBorderStyle.Solid,
                                              Color.White, 0, ButtonBorderStyle.None,
                                              Color.White, 0, ButtonBorderStyle.None);
               } 
        }
