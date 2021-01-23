    public partial class UserControl1 : UserControl
    {
        public delegate void PictureBoxClickHandler(object sender, EventArgs e);
        public event PictureBoxClickHandler PictureBoxClick;
        public delegate void PanelClickHandler(object sender, EventArgs e);
        public event PanelClickHandler PanelClick;
        public delegate void PictureBoxDoubleClickHandler(object sender, EventArgs e);
        public event PictureBoxDoubleClickHandler PictureBoxDoubleClick;
        public delegate void PictureBoxMouseMoveHandler(object sender, MouseEventArgs e);
        public event PictureBoxMouseMoveHandler PictureBoxMouseMove;
        public UserControl1()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (PictureBoxClick != null)
            {
                PictureBoxClick(sender, e);
            }
        }
        private void panel1_Click(object sender, EventArgs e)
        {
            if (PanelClick != null)
            {
                PanelClick(sender, e);
            }
        }
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (PictureBoxDoubleClick != null)
            {
                PictureBoxDoubleClick(sender, e);
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (PictureBoxMouseMove != null)
            {
                PictureBoxMouseMove(sender, e);
            }
        }
    }
    public class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
            var userControl1 = new UserControl1();
            Controls.Add(userControl1);
            userControl1.PictureBoxClick += userControl1_PictureBoxClick;
            userControl1.PanelClick += userControl1_PanelClick;
       
            userControl1.PictureBoxDoubleClick+=userControl1_PictureBoxDoubleClick;
            userControl1.PictureBoxMouseMove+=userControl1_PictureBoxMouseMove;
        }
        private void userControl1_PanelClick(object sender, EventArgs e)
        {
            //Click: Panel on userControl1
        }
        private void userControl1_PictureBoxClick(object sender, EventArgs e)
        {
            //Click: PictureBox on userControl1
        }
        private void userControl1_PictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void userControl1_PictureBoxDoubleClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
