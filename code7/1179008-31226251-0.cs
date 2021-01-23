    public partial class ingresoFirma : Form
    {
        private List<Point> stroke = null;
        private List<List<Point>> Strokes = new List<List<Point>>();
        public ingresoFirma()
        {
            InitializeComponent();
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                stroke = new List<Point>();
                stroke.Add(new Point(e.X, e.Y));
            }
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                stroke.Add(new Point(e.X, e.Y));
                if (stroke.Count == 2)
                {
                    Strokes.Add(stroke);
                }
                panel1.Refresh();
            }
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                stroke = null;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach(List<Point> curStroke in Strokes)
            {
                e.Graphics.DrawLines(Pens.Black, curStroke.ToArray());
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Strokes.Clear();
            panel1.Refresh();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPG Files(*.JPG)|*.JPG";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
                panel1.DrawToBitmap(bmp, panel1.ClientRectangle);
                bmp.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
    }
