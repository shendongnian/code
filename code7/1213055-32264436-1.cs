    public partial class UserControl1 : UserControl
    {
        public delegate void PictureBoxClickHandler(object sender, EventArgs e);
        public event PictureBoxClickHandler PictureBoxClick;
        public delegate void PanelClickHandler(object sender, EventArgs e);
        public event PanelClickHandler PanelClick;
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
        }
        private void userControl1_PanelClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void userControl1_PictureBoxClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
