        public partial class MainWindow : Window
        {
            private readonly MainWindowViewModel _vm;
    
            public MainWindow()
            {
                InitializeComponent();
    
                var vm = new MainWindowViewModel
                {
                    People = new ObservableCollection<Person>(new List<Person>
                    {
                        new Person {FirstName = "John", LastName = "Doe"},
                        new Person {FirstName = "Jane", LastName = "Doe"}
                    })
                };
    
                vm.Commit += (sender, args) =>
                {
                    MessageBox.Show("You selected: " + _vm.SelectedPerson.FirstName);
                };
    
                DataContext = vm;
                _vm = vm;
            }
        }
