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
            DataContext = new ViewModel();
        }
    }
    public class Obj : INotifyPropertyChanged
    {
        public string Text { get; set; }
        private string label;
        public string Label
        {
            get
            {
                return this.label;
            }
            set
            {
                this.label = value;
                this.RaisePropertyChaged("Label");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChaged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
    public class ViewModel
    {
        private Obj selectedItem;
        public Obj SelectedItem
        {
            get
            {
                return this.selectedItem;
            }
            set
            {
                this.selectedItem = value;
                this.selectedItem.Label = value.Text;
            }
        }
        public ObservableCollection<Obj> ObjectCollection { get; set; }
        public ViewModel()
        {
            ObjectCollection = new ObservableCollection<Obj>();
            ObjectCollection.Add(new Obj { Text = "First" });
            ObjectCollection.Add(new Obj { Text = "Second" });
            ObjectCollection.Add(new Obj { Text = "Third" });
        }
    }
    }
