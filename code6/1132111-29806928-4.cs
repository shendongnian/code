    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            var servers = new Servers(this);
            servers.SetlabelText();
        }
    }
