    public delegate void CROP_PARAMS(Point pnt, Size sz);
    public partial class Form_ScreenShot : Form
    {
        Form_TransparentSelection transpSelect;
        PictureBox pBox;
        public Form_ScreenShot()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            pBox = new PictureBox() { Dock = DockStyle.Fill, Cursor = Cursors.Cross };
            pBox.MouseDown += pBox_MouseDown;
            Controls.Add(pBox);
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics grp = Graphics.FromImage(bmp);
            grp.CopyFromScreen(0, 0, 0, 0, new Size(bmp.Width, bmp.Height), CopyPixelOperation.SourceCopy);
            pBox.Image = bmp;
        }
        void CropImage(Point startPoint, Size size)
        {
            Bitmap bmp = new Bitmap(size.Width, size.Height);
            Graphics grp = Graphics.FromImage(bmp);
            grp.DrawImage(pBox.Image, new Rectangle(0, 0, size.Width, size.Height), new Rectangle(startPoint, size), GraphicsUnit.Pixel);
            pBox.Image = bmp;
            bmp.Save("D:\\Check1.png", System.Drawing.Imaging.ImageFormat.Png);
        }
        void pBox_MouseDown(object sender, MouseEventArgs e)
        {
            transpSelect = new Form_TransparentSelection(e) {CropImage = CropImage};
            transpSelect.ShowDialog();
            Close();
        }
    }
