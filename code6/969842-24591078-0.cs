    public partial class Form1 : Form
    {
        PictureBox pictureBox1 = new PictureBox();
        public Form1()
        {
            InitializeComponent();
           
            pictureBox1.Image = Image.FromFile(@"C:\temp\test.jpg");
            pictureBox1.Parent = ribbon1;
            pictureBox1.Location = new Point(this.Width-pictureBox1.Width,10);
        }
        
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (pictureBox1.Parent == null)
            {
                pictureBox1.Parent = ribbon1;
                pictureBox1.Visible = true;
                pictureBox1.Location = new Point(this.Width - pictureBox1.Width, 10);
            }
        }
    }
