    namespace howto_floodfill {
        public partial class Form1 : Form {
            private Bitmap bitmap;
            public Form1() {
                InitializeComponent();
                this.bitmap = new Bitmap(100, 100);
                this.pictureBox1.Image = this.bitmap;
            }
            // Make a rectangle
            private void button1_Click(object sender, EventArgs e) {
                if (this.bitmap != null) {
                    this.bitmap.Dispose();
                }
                this.bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
                using (Graphics gr = Graphics.FromImage(bitmap)) {
                    gr.Clear(Color.Silver);
                    gr.DrawRectangle(Pens.Black, 5, 5, 100, 60);
                }
                this.pictureBox1.Image = this.bitmap;
            }
        }
    }
