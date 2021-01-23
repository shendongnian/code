    public partial class UserControl1 : UserControl
    {
        private Dispatcher _dispatcher; // store dispatcher when constructor is called
        public UserControl1()
        {
            InitializeComponent();
            _dispatcher = Dispatcher;
            var thread = new Thread(() => update());
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
        }
        void update()
        {
            // simulate some work
            Thread.Sleep(1000);
            // close
            _dispatcher.Invoke(() => Application.Current.MainWindow.Close());
        }
    }
