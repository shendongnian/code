    public partial class Form_TransparentSelection : Form
    {
        PictureBox pbSelection;
        Point lastPoint;
        public CROP_PARAMS CropImage { get; set; }
        public Form_TransparentSelection(MouseEventArgs e)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MouseMove += Form_TransparentSelection_MouseMove;
            MouseUp += Form_TransparentSelection_MouseUp;
            Cursor = Cursors.Cross;
            pbSelection = new PictureBox() { Size = MinimumSize = new Size(5, 5), Visible = false, BackColor = Color.LightGreen };
            Controls.Add(pbSelection);
            lastPoint = new Point(e.X, e.Y);
            pbSelection.Size = pbSelection.MinimumSize;
            pbSelection.Visible = true;
            pbSelection.Location = lastPoint;
            Opacity = .5;
            TransparencyKey = Color.LightGreen;
            BackColor = Color.Black;
        }
        void Form_TransparentSelection_MouseUp(object sender, MouseEventArgs e)
        {
            CropImage(pbSelection.Location, pbSelection.Size);
            Close();
        }
        void Form_TransparentSelection_MouseMove(object sender, MouseEventArgs e)
        {
            pbSelection.Width = e.X - lastPoint.X;
            pbSelection.Height = e.Y - lastPoint.Y;
        }
    }
