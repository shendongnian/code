    public partial class Form1 : Form {
        readonly Color mask = Color.Black;
        public Form1() {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e) {
            var me = e as MouseEventArgs;
            using (var bmp = new Bitmap(pictureBox1.Image)) {
                if (me.X < pictureBox1.Image.Width && me.Y < pictureBox1.Image.Height) {
                    var colorAtMouse = bmp.GetPixel(me.X, me.Y);
                    if (colorAtMouse.ToArgb() == mask.ToArgb()) {
                        MessageBox.Show("Mask clicked!");
                    }
                }
            }
        }
    }
