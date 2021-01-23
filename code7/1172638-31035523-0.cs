    public class BaseForm : Form
    {
        protected void DrawBorder(Color c)
        {
            var g = CreateGraphics();
            var br = new SolidBrush(c);
            var p = new Pen(br, 4);
            var r = new Rectangle(0, 0, 50, 50);
            g.DrawRectangle(p, r);
           
            p.Dispose();
            br.Dispose();
            g.Dispose();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawBorder(Color.Red);
            base.OnPaint(e);
        }
    }
