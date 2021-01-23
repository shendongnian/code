    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
            ServerCommunicator.Connect();
            // Sending a message:
            ServerCommunicator.SendMessage("Hello server!");
        }
    }
