    public partial class UserControl2 : UserControl
    {
        private TextBox txt = null;
        public UserControl2()
        {
            InitializeComponent();
        }
        public TextBox TextBox
        {
            set
            {
                txt = value;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txt != null)
                MessageBox.Show(txt.Text);
        }
    }
