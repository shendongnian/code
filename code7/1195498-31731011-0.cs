    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("shlwapi.dll")]
        public static extern int ColorHLSToRGB(int H, int L, int S);
        int x = 0;
        int width = 40;
        int y = 300;
        int height = 100;
        int h = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (x + width > panel1.ClientSize.Width) // if drawing the next block would exceed the panel width...
            {
                // capture what's currently on the screen
                Bitmap bmp = new Bitmap(x, height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(panel1.PointToScreen(new Point(0, y)), new Point(0, 0), bmp.Size);
                }
                // draw it shifted to the left
                using (Graphics g = panel1.CreateGraphics())
                {
                    g.DrawImage(bmp, new Point(-width, y));
                }
                // move x back so the new rectangle will draw where the last one was previously
                x = x - width;                
            }
            // draw the new block and increment values
            panel_Paint();
            x = x + width;
            h = h + width;
            if (h >= 240)
            { 
                h = 0;
            }
        }
        private void panel_Paint()
        {
            int val;
            Color color;
            val = ColorHLSToRGB(h, 128, 240);
            color = ColorTranslator.FromWin32(val);
            using (Graphics g = panel1.CreateGraphics())
            {
                using (SolidBrush sb = new SolidBrush(color))
                {
                    g.FillRectangle(sb, x, y, width, height);
                }
            }
        }
    }
