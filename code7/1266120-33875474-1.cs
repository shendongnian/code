    namespace WpfApplication
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Data();
        }
    }
    public class Data:INotifyPropertyChanged
    {
        private bool visibility;
        public bool Visibility 
        { 
            get
            {
                return this.visibility;
            }
            set
            {
                this.visibility = value;
                this.RaisePropertyChanged("Visibility");
            }
        }
        private double percentage;
        public double Percentage 
        { 
            get
            {
                return this.percentage;
            }
            set
            {
                this.percentage = value;
                this.RaisePropertyChanged("Percentage");
            }
        }
        public Data()
        {
            Action SomeWork = new Action(DoWork);
            IAsyncResult result = SomeWork.BeginInvoke(null, null);
        }
        public void DoWork()
        {
            System.Threading.Thread.Sleep(3000);
            Visibility = true;
            for (int i=0;i<100;i++)
            {
                System.Threading.Thread.Sleep(300);
                Percentage += 1;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string info)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
    }
