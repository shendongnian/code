    public class MyButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            using (Pen p = new Pen(BackColor, 5))
            {
                p.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                pevent.Graphics.DrawRectangle(p, ClientRectangle);
            }
        }
    }
