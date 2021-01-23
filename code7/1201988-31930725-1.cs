    public partial class Form1 : Form
    {
        private List<Point> DrawEllipsesAt = new List<Point>();
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
            this.DrawEllipsesAt.Add(this.PointToClient(Cursor.Position));
            this.Invalidate();
        }
        private void Form1_Paint1(object sender, PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            if (this.DrawEllipsesAt.Count > 0)
            {
                using (Pen myPen = new Pen(System.Drawing.Color.Green, 5))
                {
                    foreach (Point pt in this.DrawEllipsesAt)
                    {
                        Rectangle myRectangle = new Rectangle(pt, new Size(0, 0));
                        myRectangle.Inflate(new Size(125, 100));
                        G.DrawEllipse(myPen, myRectangle);
                    }
                }
            }
        }
    }
