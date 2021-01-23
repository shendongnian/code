    namespace WpfApplication2
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
    public class Data
    {
        public ObservableCollection<int> Items { get; set; }
        public Data()
        {
            Items = new ObservableCollection<int>();
            Filters();
        }
        public void Filters()
        {
            Task.Factory.StartNew(DoWork);
        }
        public void DoWork()
        {
                int i = 0;
                while (true)
                {
                    System.Threading.Thread.Sleep(1000);
                    App.Current.Dispatcher.BeginInvoke(new Action(() => { Items.Add(++i); }));   
                }
        }
    }
    }
