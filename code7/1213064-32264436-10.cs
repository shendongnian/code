    public class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
            PictureBox pictureBox = userControl1.ChildPictureBox;
            //now work with pictureBox here
            pictureBox.Click += pictureBox_Click;
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
