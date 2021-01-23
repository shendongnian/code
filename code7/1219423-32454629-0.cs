    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Record = new Entity();
        }
        public List<Client_Type> Client_type_list
        {
            get { return GetClientTypes(); }
        }
        private Entity record;
        public Entity Record
        {
            get { return record; }
            set
            {
                record = value;
                OnPropertyChanged("Record");
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public List<Client_Type> GetClientTypes()
        {
            List<Client_Type> ClientType = new List<Client_Type>();
            {
                ClientType.Add(new Client_Type() { Client_type1 = "a", Client_typeId = "1" });
                ClientType.Add(new Client_Type() { Client_type1 = "b", Client_typeId = "2" });
            }
            return ClientType;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Record.Client_Type.Client_typeId);
        }
    }
