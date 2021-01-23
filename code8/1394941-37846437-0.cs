    public class Person {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
    public class PersonListViewModel : DependencyObject {
        public ObservableCollection<Person> Items { get; set; }
        public Person CurrentPerson
        {
            get { return (Person)GetValue(CurrentPersonProperty); }
            set { SetValue(CurrentPersonProperty, value); }
        }
        public static readonly DependencyProperty CurrentPersonProperty = DependencyProperty.Register("CurrentPerson", typeof(Person), typeof(PersonListViewModel));
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public PersonListViewModel() {
            Items = new ObservableCollection<Person>();
            AddCommand = new RelayCommand(p=> add() );
            EditCommand = new RelayCommand(p=> { return CurrentPerson != null; }, p => edit());
        }
        private void add() {
            Person p= new Person();
            p.Id = Items.Count();
            p.Name = "New Name";
            p.Birthday = DateTime.Now;
            Items.Add(p);
        }
        private void edit() {
            var viewModel = new PersonItemViewModel(CurrentPerson);
            var view = new View.PersonEditWindow();
            view.DataContext = viewModel;
            view.Show(); 
        }
    }
    public class PersonItemViewModel : DependencyObject {
        Person person;
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(PersonItemViewModel) );
        public DateTime Birthday
        {
            get { return (DateTime)GetValue(BirthdayProperty); }
            set { SetValue(BirthdayProperty, value); }
        }
        public static readonly DependencyProperty BirthdayProperty = DependencyProperty.Register("Birthday", typeof(DateTime), typeof(PersonItemViewModel));
        public PersonItemViewModel() {
        }
        public PersonItemViewModel(Person source) {
            this.person = source;
            Name =  person.Name;
            Birthday = person.Birthday;
        }
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e) {
            base.OnPropertyChanged(e);
            if (e.Property == NameProperty) {
                person.Name = (string) e.NewValue;
            }
            if (e.Property == BirthdayProperty) {
                person.Birthday = (DateTime)e.NewValue;
            }
        }
    }
