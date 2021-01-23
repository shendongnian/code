    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
            {
                var observable = new ObservableCollection<Test>();
                observable.Add(new Test("A"));
                observable.Add(new Test("B"));
                observable.Add(new Test("C"));
                this.lst.ItemsSource = observable;
            }
        }
    
        public class Test
        {
            public Test(string dateTime)
            {
                this.Data = dateTime;
            }
    
            public string Data { get; set; }
        }
