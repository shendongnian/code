    public partial class Form1 : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public Form1()
        {
            InitializeComponent();
        }
        private void pbxBigCat_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                lastLocation = e.Location;
            }
        }
        private void pbxBigCat_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                pbxBigCat.Location = new Point((pbxBigCat.Location.X - lastLocation.X + e.X), (pbxBigCat.Location.Y - lastLocation.Y) + e.Y);
                label1.Text = pbxBigCat.Location.X.ToString() + "/" + pbxBigCat.Location.Y.ToString();
            }
        }
        private void pbxBigCat_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
