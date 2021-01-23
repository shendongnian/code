    public partial class Client : Form
    {
        private UserInterface ui1;
        public Client(UserInterface ui1)
        {
            InitializeComponent();
            this.ui1 = ui1;
            ui1.SomeEvent += UI1_SomeEvent;
        }
        private void UI1_SomeEvent(object sender, EventArgs e)
        {
            //Your code...
            CheckBox c = sender as CheckBox;
            if(c.Checked == true)
            {
                MessageBox.Show("true");
            }
            else
            {
                MessageBox.Show("false");
            }
        }
        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            ui1.SomeEvent -= UI1_SomeEvent;
        }
    }
