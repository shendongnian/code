    public partial class Form1 : Form
    {
        private bool _drawRectangle = false;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Paint += new PaintEventHandler(this.pictureBox1_Paint);
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (_drawRectangle) {
                Graphics g = e.Graphics;
                // use g to do your drawing
            }
        }
    }
