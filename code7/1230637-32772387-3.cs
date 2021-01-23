        public partial class UserLabel : View
        {
            public UserLabel(IHost host) : base(host)
            {
                InitializeComponent();
            }
    
            private void SubmitButton_Click(object sender, System.EventArgs e)
            {
                Host.SwitchView("UserText");
            }
        }
