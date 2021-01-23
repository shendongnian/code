    public partial class Form1 : Form
    {
        bool attempt = false;
        int xc, yc, Br = 0, Brkr = 0;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (attempt == false)
            {
                if ((e.X - xc) * (e.X - xc) + (e.Y - yc) * (e.Y - yc) <= 225) Br++;
                Text = Br + " FROM " + Brkr++;
            }
            attempt = true;
        }
        public void Paaint()
        {
            SolidBrush cetka = new SolidBrush(Color.Red);
            Graphics g = CreateGraphics();
            xc = R.Next(15, ClientRectangle.Width - 15);
            yc = R.Next(15, ClientRectangle.Height - 15);
            g.FillEllipse(cetka, xc - 15, yc - 15, 30, 30);
            Brkr++;
            label1.Text = Br + "FROM" + Brkr;
            attempt = false;
            g.Dispose();
            cetka.Dispose();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Paaint();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
        Random R = new Random();
        public Form1()
        {
            InitializeComponent();
        }
    }
