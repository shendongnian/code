    public partial class SecondPage : Window
    {
        SecondPageViewModel spvm = new SecondPageViewModel();
        public event raiseEventEventHandler raiseEventFromSecondPage;
        public SecondPage()
        {
            this.DataContext = spvm;
            spvm.raiseEvent += raiseEvent_EventHandler;
            InitializeComponent();
        }
        public void raiseEvent_EventHandler()
        {
            if (raiseEventFromSecondPage != null)
                raiseEventFromSecondPage();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            spvm.raiseEventActivate();
        }
    }
