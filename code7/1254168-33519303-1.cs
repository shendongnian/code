    public partial class Form1 : Form
    {
        private readonly string _sessId;
        private readonly string _server;
        private readonly string _sessName;
        public Form1(string sessId, string server, string sessName)
        {
            _sessId = sessId;
            _server = server;
            _sessName = sessName;
            InitializeComponent();
            ...
        }
