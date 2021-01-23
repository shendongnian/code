    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            FillListWithSomeExamples();
        }
        private void FillListWithSomeExamples()
        {
            TypesOfContacts.Add(new TypesOfContact {Id = 1, Type = "Email"});
            TypesOfContacts.Add(new TypesOfContact { Id = 2, Type = "Telephone" });
        }
        public TypesOfContact SelectedTypesOfContact { get; set; }
        public ObservableCollection<TypesOfContact> TypesOfContacts { get; set; } = new ObservableCollection<TypesOfContact>();
    }
