    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics G;
        Pen myPen = new Pen(Color.Black);
        Point sp = new Point(0, 0);
        Point ep = new Point(0, 0);
        int ctrl = 0;
        public Form1()
        {
            InitializeComponent();
            // create bitmap
            bmp = new Bitmap(panel1.Width, panel1.Height);
            // create Graphics
            G = Graphics.FromImage(bmp);
            G.Clear(Color.Black);
            // redraw panel
            panel1.Invalidate();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // draw bitmap on panel
            if (bmp != null)
                e.Grahics.DrawImage(bmp, Point.Empty);
        }
        // shortened for clarity
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(ctrl == 1)
            {
                ep = e.Location;
                // draw onto graphics -> bmp
                G.DrawLine(myPen, sp, ep);
            }
            sp = ep;
            // redraw panel
            panel1.Invalidate();
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Title = "Save Image";
            dlgSave.Filter = "Bitmap Images (*.bmp)|*.bmp|All Files (*.*)|*.*";
            if (dlgSave.ShowDialog(this) == DialogResult.OK)
            {
                 bmp.Save(dlgSave.FileName);
            }
        }
    }
