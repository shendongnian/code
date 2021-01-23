        public partial class UserText : View
        {
            public UserText(IHost host) : base(host)
            {
                InitializeComponent();
            }
    
            private void LoginButton_Click(object sender, EventArgs e)
            {
                Host.SwitchView("UserLabel");
            }
        }
