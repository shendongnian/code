    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            pictureBox1.AllowDrop = true;
            pictureBox2.AllowDrop = true;
            pictureBox2.Image = Image.FromFile(@"C:\TitleBar.jpg");
        }
    
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                pictureBox2.DoDragDrop(pictureBox2.Image, DragDropEffects.Move);
                pictureBox2.Image = null;
            }
    
        }
    
        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
    
        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            pictureBox1.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
        }
    }
