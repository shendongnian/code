    public partial class UserControlB: UserControl
    {
        UserControlA userControlA;
    
        public UserControlB(UserControlA ucA)
        {
            userControlA = ucA;
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            string myString = userControlA.TexBoxText;
        }
    }
