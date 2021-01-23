    public class DrawTextImage : Control
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            int a = 0;
            SolidBrush textColor = new SolidBrush(Color.Black);
            using (SolidBrush brush = new SolidBrush(Color.Red))
            {
                //Note:  here you might want to replace the Size parameter with e.Bounds
                e.Graphics.FillRectangle(brush, new Rectangle(a, a, Size.Width, Size.Height));
                e.Graphics.DrawString("Text", Font, textColor, new PointF(50, 50));
            }
        }
    }
