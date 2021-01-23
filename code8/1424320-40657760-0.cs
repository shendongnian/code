    public partial class Player : Window
    {
        private WebBrowserHostUIHandler _wbHandler;
    
        public Player()
        {
            InitializeComponent();
            ...
            _wbHandler = new WebBrowserHostUIHandler(MyWebBrower);
            _wbHandler.IsWebBrowserContextMenuEnabled = true;
        }
    }
