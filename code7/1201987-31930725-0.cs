    public partial class Form1 : Form
    {
        private Point DrawEllipseAt;
        private bool DrawEllipse = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Paint += Form1_Paint1;
            this.Click += Form1_Click;
        }
        private void Form1_Click(object sender, EventArgs e)
        {
            this.DrawEllipseAt = this.PointToClient(Cursor.Position);
            this.DrawEllipse = true;
            this.Invalidate();
        }
        private void Form1_Paint1(object sender, PaintEventArgs e)
        {
            if (this.DrawEllipse)
            {
                Graphics G = e.Graphics;
                Rectangle myRectangle = new Rectangle(DrawEllipseAt, new Size(0, 0));
                myRectangle.Inflate(new Size(125, 100));
                using (Pen myPen = new Pen(System.Drawing.Color.Green, 5))
                {
                    G.DrawEllipse(myPen, myRectangle);
                }
            }
        }
    }
