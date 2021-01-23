    public partial class DraggablePictureBox : UserControl
    {
        public DraggablePictureBox()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Sets image of inner picture
        /// </summary>
        public Image Image
        {
            get {
                return InnerPictureBox.Image;
            }
            set
            {
                InnerPictureBox.Image = value;
            }
        }
        private void InnerPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging == true)
            {
                this.Left += e.X - move.X;
                this.Top += e.Y - move.Y;
                this.BringToFront();
            }
        }
        private void InnerPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
        private void InnerPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            move = e.Location;
        }
        private Point move;
        private bool isDragging = false;
    }
