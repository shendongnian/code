    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private double _rcXValue;
        public double RcXValue
        {
          get { return _rcXValue; }
          set
          {
            _rcXValue = value;
            if (PropertyChanged != null)
              PropertyChanged(this, new PropertyChangedEventArgs("RcXValue"));
          }
        }
    
        public MainWindow()
        {
          InitializeComponent();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
          for (int i = 0; i < 10; i++)
          {
            RcXValue += 20; //UI should be updated automatically
            calculateIntersections();
            await Task.Delay(1000);
          }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    }
