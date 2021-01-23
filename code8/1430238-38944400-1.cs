    namespace WinForms_PaintTest
    {
        public partial class Form1 : Form
        {
            private Pen pen;
            private Bitmap bitmap;
    
            public Form1()
            {
                InitializeComponent();
                this.pen = new Pen(Color.Black, 1);
                this.bitmap = new Bitmap(this.panel1.Width, this.panel1.Height);
                this.panel1.BackgroundImage = this.bitmap;
            }
    
            private void panel1_MouseMove(Object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    using (Graphics g = Graphics.FromImage(this.bitmap))
                    {
                        g.DrawRectangle(this.pen, e.Location.X, e.Location.Y, 1, 1);
                    }
                    this.panel1.Refresh();
                }
            }
    
            private void Form1_FormClosed(Object sender, FormClosedEventArgs e)
            {
                this.pen.Dispose();
                this.bitmap.Dispose();
            }
        }
    }
