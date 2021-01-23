    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Threading;
    
    namespace WpfWindowInAnotherThread
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            static int _threadNumber = 0;
            readonly Timer _timer;
            int _Counter;
    
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
    
            public int ThreadId
            {
                get { return Thread.CurrentThread.ManagedThreadId; }
            }
            public string ThreadName
            {
                get { return Thread.CurrentThread.Name; }
            }
            public int Counter
            {
                get { return _Counter; }
                set { _Counter = value; PropertyChanged(this, new PropertyChangedEventArgs("Counter")); }
            }
    
            public MainWindow()
            {
                DataContext = this;
                _timer = new Timer((o) => {
                    Counter++;
                    MainWindow wnd = o as MainWindow;
                    wnd.Dispatcher.BeginInvoke(new Action<MainWindow>(ChangeStackPanelBackground), wnd);
                }, this, 0, 200);
                InitializeComponent();
            }
            private void btnStartTheSameThread_Click(object sender, RoutedEventArgs e)
            {
                MainWindow mainWnd = new MainWindow();
                mainWnd.Show();
            }
            private void btnStartInNewThread_Click(object sender, RoutedEventArgs e)
            {
                Thread thread = new Thread(new ThreadStart(ThreadMethod));
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start();
            }
            private static void ThreadMethod()
            {
                Thread.CurrentThread.Name = "MainWindowThread# " + _threadNumber.ToString();
                Interlocked.Increment(ref _threadNumber);
    
                MainWindow mainWnd = new MainWindow();
                mainWnd.Show();
    
                Dispatcher.Run();
            }
            private static void ChangeStackPanelBackground(MainWindow wnd)
            {
                Random rnd = new Random(Environment.TickCount);
                byte[] rgb = new byte[3];
                rnd.NextBytes(rgb);
                wnd.stackPanelCounter.Background = new SolidColorBrush(Color.FromArgb(0xFF, rgb[0], rgb[1], rgb[2]));
            }
        }
    }
