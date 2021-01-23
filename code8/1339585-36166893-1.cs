    public ChatView : UserControl
    {
        public ChatView()
        {
            InitializeComponent();
            DataContext = new ChatViewModel();
        }
    }
