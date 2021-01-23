    public partial class Form1 : Form
    {
        [DllImport("shlwapi.dll")]
        public static extern int ColorHLSToRGB(int H, int L, int S);
        int x = 0;
        int width = 40;
        int y = 300;
        int height = 100;
        int h = 0;
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            panel1.Paint += Panel1_Paint;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int numBlocks = (int)(panel1.Width / width);
            bmp = new Bitmap(numBlocks * width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(panel1.BackColor);
            }
        }
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            if (bmp != null)
            {
                e.Graphics.DrawImage(bmp, new Point(0, y));
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                if (x + width > bmp.Width) // if drawing the next block would exceed the bmp width...
                {                
                    g.DrawImage(bmp, new Point(-width, 0)); // draw ourself shifted to the left   
                    x = x - width;
                }
               
                // draw the new block 
                int val;
                Color color;
                val = ColorHLSToRGB(h, 128, 240);
                color = ColorTranslator.FromWin32(val);
                using (SolidBrush sb = new SolidBrush(color))
                {
                    g.FillRectangle(sb, x, 0, width, height);
                }
            }
            x = x + width;
            h = h + width;
            if (h >= 240)
            { 
                h = 0;
            }
            panel1.Invalidate(); // force panel1 to redraw itself
        }
    }
