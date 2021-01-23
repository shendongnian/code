    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            foreach (Control control in this.Controls)
            {
                control.Click += new EventHandler(control_Click);
            }
        }
        private void control_Click(object sender, EventArgs e)
        {
            this.UserControl1_Click(sender, e);
        }
        private void UserControl1_Click(object sender, EventArgs e)
        {
        }
    }
