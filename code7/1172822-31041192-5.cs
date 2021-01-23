    public partial class MainWindow : Window
    {
        public ObservableCollection<Model> NameTab { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            NameTab = new ObservableCollection<Model>();
            NameTab.Add(new Model() { id_czesci_symbol = 1, Nazwa = "Nazwa1", Symbol = "Symbol1" });
            NameTab.Add(new Model() { id_czesci_symbol = 2, Nazwa = "Nazwa2", Symbol = "Symbol2" });
            NameTab.Add(new Model() { id_czesci_symbol = 3, Nazwa = "Nazwa3", Symbol = "Symbol3" });
            this.DataContext = this;
        }
    }
