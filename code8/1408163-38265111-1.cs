    public class Client : Form
    {
        private int _userId;
        public Client(int userId, string username)
        {
            InitializeComponent();
            _userId = userId;
            lblUser.Text = username;
            DisplayData();
            FillData();
        }
    }
