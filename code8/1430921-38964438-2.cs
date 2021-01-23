    public class A
    {
        public string Str { get; set; }
    }
    
    public class ParentAViewModel : INotifyPropertyChanged
    {
        private int _currentIndex;
    
        public ParentAViewModel()
        {
            Items = new List<A>();
        }
    
        public string Name { get; set; }
        public List<A> Items { get; set; }
    
        public int CurrentIndex
        {
            get
            {
                return _currentIndex;
            }
            set
            {
                _currentIndex = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CurrentItem));
            }
        }
    
        public string CurrentItem => Items[CurrentIndex].Str;
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    public partial class MainWindow : Window
    {
        public ParentAViewModel ObjectParrentA { get; set; }
        public int SelectedItem { get; set; }
    
        public MainWindow()
        {
            ObjectParrentA = new ParentAViewModel();
            ObjectParrentA.Items.Add(new A() { Str = "1" });
            ObjectParrentA.Items.Add(new A() { Str = "2" });
            ObjectParrentA.Items.Add(new A() { Str = "3" });
            // here is binding of ObjectParrentA by JSON data.
            SelectedItem = 0;
            this.DataContext = this;
    
            InitializeComponent();
        }
    
        private void NextItem_Click(object sender, RoutedEventArgs e)
        {
            ObjectParrentA.CurrentIndex++;
        }
    }
