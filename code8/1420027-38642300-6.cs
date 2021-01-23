    public partial class MainWindow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public MainWindow()
        {
    
            InitializeComponent();
            this.Ponies.Add(new Pony() { Id = 0, Color = Brushes.DeepSkyBlue, Name = "Slayer" });
            this.Ponies.Add(new Pony() { Id = 1, Color = Brushes.DeepPink, Name = "Murder" });
            this.Ponies.Add(new Pony() { Id = 2, Color = Brushes.Yellow, Name = "Brutal" });
            this.DataContext = this;
        }
    
        private ObservableCollection<Pony> _ponies = new ObservableCollection<Pony>();
        private Pony _selectedPony;
        public ObservableCollection<Pony> Ponies => this._ponies;
    
    
        public Pony SelectedPony {
            get { return _selectedPony; }
            set {
                if (this._selectedPony == value) return;
                _selectedPony = value;
                this.OnPropertyChanged("SelectedPony");
            }
        }
    }
    
    public class Pony : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string _name;
    
        public string Name {
            get { return this._name; }
            set {
                this._name = value;
                this.OnPropertyChanged("Name");
            }
        }
    
        public Brush Color { get; set; }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
