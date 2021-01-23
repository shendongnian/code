        public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dataGrid = SelectDataGrid;
            var selected = dataGrid.SelectedItems.Cast<Person>().ToList();
            var mostFirst = selected.FirstOrDefault();
        }
    }
    public class Person : BaseObservableObject
    {
        private string _lName;
        private string _fName;
        private bool _checked;
        public bool IsChecked
        {
            get { return _checked; }
            set
            {
                _checked = value;
                OnPropertyChanged();
            }
        }
        public string LNAME
        {
            get { return _lName; }
            set
            {
                _lName = value;
                OnPropertyChanged();
            }
        }
        public string FNAME
        {
            get { return _fName; }
            set
            {
                _fName = value;
                OnPropertyChanged();
            }
        }
    }
