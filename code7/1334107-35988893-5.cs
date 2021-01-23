        private ObservableCollection<Person> _people = new ObservableCollection<Person>();
        public ObservableCollection<Person> Person
        {
            get { return _people; }
        }
        private DelegateCommand _getNewTreeViewItemCommand = null;
        public ICommand GetNewTreeViewItemCommand { get { return _getNewTreeViewItemCommand; } }
        private void LoadNewTreeViewITem(object param)
        {
            var tuple = (Tuple<object, object>)param;
            object sender = tuple.Item1;
            RoutedEventArgs e = tuple.Item2 as RoutedEventArgs;
            System.Diagnostics.Debug.WriteLine(sender);
            System.Diagnostics.Debug.WriteLine(e.RoutedEvent);
        }
        public MainWindowViewModel()
        {
            _getNewTreeViewItemCommand = new DelegateCommand(LoadNewTreeViewITem, (o) => true);
            for (int i = 0; i < 10; i++)
            {
                var newPerson = new Person() { Description = i.ToString() };
                for (int j = 0; j < 10; j++)
                {
                    newCode.Children.Add(new Person() { Description = i.ToString() + j.ToString() });
                }
                _people.Add(newCode);
            }
        }
