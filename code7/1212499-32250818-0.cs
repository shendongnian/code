    public partial class MainWindow : Window
    {
        private ViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new ViewModel();
            this.DataContext = vm;
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ComboBox1.Text) && !string.IsNullOrEmpty(ComboBox2.Text))
            {
                vm.AddDataToModel(ComboBox1.Text, ComboBox2.Text);
            }
        }
    }
    public class ViewModel
    {
        public List<String> DataModelProperties { get; set; }
        private ObservableCollection<DataModel> _DataModelList;
      
        public ViewModel()
        {
            _DataModelList = new ObservableCollection<DataModel>();
            DataModelProperties = typeof(DataModel).GetProperties().Select(s => s.Name).ToList();
        }
        public void AddDataToModel(string cmbx1Val,string cmbx2Val)
        {
            _DataModelList.Add(new DataModel() { Name = cmbx1Val, Code = cmbx2Val, Desc = "Desc1" });
        }
        public ObservableCollection<DataModel> DataModelList
        {
            get
            {
                return _DataModelList;
            }
            set
            {
                _DataModelList = value;
               
            }
        }
    }
