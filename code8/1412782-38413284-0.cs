    public partial class Form1 : Form
    {
        float t = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Image img = Resources.Image1;
            float dx = img.Width, dy = img.Height;
            float r = 100;
            e.Graphics.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);
            // you must set the x,y coordinate of the center of the image
            // according to your path.
            // If it is a line use linear interpolation
            // x = x_start + t*(x_end-x_start);
            // y = y_start + t*(y_end-y_start);
            float x = (float)(r * Math.Cos(2 * Math.PI * t));
            float y = -(float)(r * Math.Sin(2 * Math.PI * t));
            e.Graphics.DrawImageUnscaled(img, (int)(x - dx / 2), (int)(y - dy / 2));
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (t >= 1)
            {
                t -= 1;
            }
            t += 0.02f;
            pictureBox1.Refresh();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 20;
            timer1.Start();
        }
    }
