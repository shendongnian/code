    namespace WpfApplication55
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            TestCombo TC = new TestCombo();
            CancellationTokenSource cts;
            public MainWindow()
            {
                DataContext = TC;
                InitializeComponent();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                if (cts != null)
                {
                    cts.Cancel();
                }
                
                cts = new CancellationTokenSource();
                
                await TC.DoAsync(60, cts.Token);
            }
    
            private void Button_Click1(object sender, RoutedEventArgs e)
            {
                if (cts != null)
                {
                    cts.Cancel();
                }
                
                cts = new CancellationTokenSource();
                
                await TC.DoAsync(120, cts.Token);
            }
        }
    
        public class TestCombo:INotifyPropertyChanged
        {
            private int someData;
            public int SomeData 
            {
                get { return someData; }
                set { someData = value; RaisePropertyChanged("SomeData"); }
            }
    
            public void StartCount(int input)
            {
                SomeData = input;
                while (input>0)
                {
                    System.Threading.Thread.Sleep(1000);
                    input -= 1;
                    SomeData = input;
                }
            }
    
            public Task DoAsync(int input, CancellationToken cancellationToken)
            {   
                return Task.Run(StartCount, cancellationToken);
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void RaisePropertyChanged (string info)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
 
