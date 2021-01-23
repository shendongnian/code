    public partial class Form1 : Form
    {
        public Form1()
        {
            //InitializeComponent();
            Width = 800;
            Height = 600;
            pictureBox = new PictureBox { Parent = this, Dock = DockStyle.Top, Height = 500 };
            pictureBox.ImageLocation = "pic.jpg";
            pictureBox.Click += PictureBox_Click;
        }
        PictureBox pictureBox;
        List<Point> points = new List<Point>();
        private void PictureBox_Click(object sender, EventArgs e)
        {
            var point = pictureBox.PointToClient(MousePosition);
            points.Add(point);
            var iconBox = new PictureBox { Parent = pictureBox, Location = point, Size = new Size(32, 32) };
            iconBox.Image = SystemIcons.Hand.ToBitmap();
            iconBox.Click += IconBox_Click;
        }
        private void IconBox_Click(object sender, EventArgs e)
        {
            var pb = (PictureBox)sender;
            points.Remove(pb.Location);
            pb.Parent = null;
            pb.Click -= IconBox_Click;
            pb.Dispose();
        }
    }
