    public partial class Form1 : Form
    {
        Form overlay;
    
        bool a, b;
    
        int c, d, f, g;
    
        Point ptNope, ptHold, ptTest, ptDown = Point.Empty;
    
        List<Control> controlSelection = new List<Control>();
    
        List<Control> getControls(Control container, Rectangle rect)
        {
            rect = RectangleToClient(rect);
    
            controlSelection = new List<Control>();
            foreach (Control ctl in container.Controls)
                if (rect.Contains(ctl.Bounds))
                {
                    controlSelection.Add(ctl);
                    foreach (Control ct in ctl.Controls) controlSelection.Add(ct);
                }
    
            return controlSelection;
        }
    
        public Form1()
        {
            InitializeComponent();
    
            overlay = new Form()
            {
                FormBorderStyle = FormBorderStyle.None,
                BackColor = Color.Fuchsia,
                Opacity = 0.2f,
                TopMost = true
            };
        }
    
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ptNope.X = this.Left; ptNope.Y = this.Top;
            ptDown = e.Location;
            overlay.Show();
        }
    
        public static int vise(int value, int min, int max) { return (value < min) ? min : (value > max) ? max : value; }
    
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ptHold = PointToScreen(ptDown);
                ptTest = PointToScreen(e.Location);
    
                a = (ptTest.X < ptHold.X); b = (ptTest.Y < ptHold.Y);
    
                c = a ? ptTest.X : ptHold.X; c = vise(c, ptNope.X, ptNope.X + this.Width);
                d = b ? ptTest.Y : ptHold.Y; d = vise(d, ptNope.Y, ptNope.Y + this.Height);
                f = a ? (ptHold.X - ptTest.X) : (ptTest.X - ptHold.X); f = vise(f, 0, a ? (ptHold.X - ptNope.X) : ((ptNope.X + this.Width) - ptHold.X));
                g = b ? (ptHold.Y - ptTest.Y) : (ptTest.Y - ptHold.Y); g = vise(g, 0, b ? (ptHold.Y - ptNope.Y) : ((ptNope.Y + this.Height) - ptHold.Y));
    
                overlay.Left = c; overlay.Top = d; overlay.Width = f; overlay.Height = g;
    
                controlSelection = getControls(this, Bounds);
                foreach (Control c in controlSelection) { c.BackColor = SystemColors.Control; }
    
                controlSelection = getControls(this, overlay.Bounds);
                foreach (Control c in controlSelection) { c.BackColor = Color.Fuchsia; }
    
                label1.Text = controlSelection.Count + " Control(s) grabbed";
            }
        }
    
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            overlay.Hide(); label1.Text = "";
        }
    }
