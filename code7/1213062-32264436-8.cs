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
