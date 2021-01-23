        public partial class UserControl1 : UserControl
    {
        public event EventHandler btn1Click;
        public UserControl1()
        {
            InitializeComponent();
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            if (btn1Click!= null)
                btn1Click(sender, e);
        }
    }
