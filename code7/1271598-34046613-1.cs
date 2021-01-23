    public partial class MainWindow : Window
    {
       
        Thread myLittleThread;
        bool stop;
        public string ImageSource
        {
            set
            {
                myLittleImage.Source = new BitmapImage(new Uri(value));
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            InitThread();
        }
        private void InitThread()
        {
            myLittleThread = new Thread(DoWork);
            stop = false;
            Application.Current.Exit += MyLittleApplication_Exit;
            myLittleThread.Start();
        }
        private void MyLittleApplication_Exit(object sender,EventArgs e)
        {
            stop = true;
        }
        private void DoWork(){
            string newImageSource;
            while (!stop)
            {
                if (DateTime.Now.Second % 2 == 0)
                {
                    newImageSource = "SomeRandomFooImage.png";
                }
                else
                {
                    newImageSource = "MyLittleRandomImage.png";
                }
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    ImageSource = newImageSource;
                }));
                Thread.Sleep(250);
            }
        }
    }
